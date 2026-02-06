import { useEffect, useMemo, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { useAuth } from "../auth";
import { api } from "../api";
import { adminEntities, enumOptions, FieldDef } from "./AdminConfig";

type RecordShape = { [key: string]: unknown; id?: number };

function toCamel(name: string) {
  return name.charAt(0).toLowerCase() + name.slice(1);
}

function toInputValue(type: FieldDef["type"], value: unknown) {
  if (value == null) return "";
  if (type === "datetime") {
    const date = new Date(String(value));
    if (Number.isNaN(date.valueOf())) return "";
    const iso = new Date(date.getTime() - date.getTimezoneOffset() * 60000).toISOString();
    return iso.slice(0, 16);
  }
  return String(value);
}

function fromInputValue(type: FieldDef["type"], value: string) {
  if (value === "" || value == null) return null;
  if (type === "number") return Number(value);
  if (type === "bool") return value === "true";
  if (type === "datetime") return new Date(value).toISOString();
  return value;
}

export default function AdminEntityPage() {
  const { entityKey } = useParams();
  const { user } = useAuth();
  const navigate = useNavigate();
  const config = useMemo(() => adminEntities.find((e) => e.key === entityKey), [entityKey]);
  const [records, setRecords] = useState<RecordShape[]>([]);
  const [selectedId, setSelectedId] = useState<number | null>(null);
  const [formState, setFormState] = useState<Record<string, string>>({});
  const [lookupOptions, setLookupOptions] = useState<Record<string, RecordShape[]>>({});

  useEffect(() => {
    if (!user || !user.isAdmin) {
      navigate("/login");
    }
  }, [user, navigate]);

  useEffect(() => {
    if (!config) return;
    api.get<RecordShape[]>(config.endpoint).then(setRecords).catch(console.error);
    setSelectedId(null);
    setFormState({});
    const lookupFields = config.fields.filter((f) => f.type === "lookup" && f.lookup);
    if (!lookupFields.length) {
      setLookupOptions({});
      return;
    }
    Promise.all(
      lookupFields.map(async (field) => {
        const items = await api.get<RecordShape[]>(field.lookup!.endpoint);
        return [field.name, items] as const;
      })
    )
      .then((entries) => {
        const map: Record<string, RecordShape[]> = {};
        entries.forEach(([name, items]) => {
          map[name] = items;
        });
        setLookupOptions(map);
      })
      .catch(console.error);
  }, [config]);

  if (!user || !user.isAdmin || !config) {
    return null;
  }

  const handleSelect = (record: RecordShape) => {
    setSelectedId(record.id as number);
    const nextState: Record<string, string> = {};
    config.fields.forEach((field) => {
      const key = toCamel(field.name);
      nextState[field.name] = toInputValue(field.type, record[key]);
    });
    setFormState(nextState);
  };

  const handleInput = (field: FieldDef, value: string) => {
    setFormState((prev) => ({ ...prev, [field.name]: value }));
  };

  const buildPayload = () => {
    const payload: Record<string, unknown> = {};
    config.fields.forEach((field) => {
      const raw = formState[field.name] ?? "";
      const parsed = fromInputValue(field.type, raw);
      if (parsed !== null) {
        payload[toCamel(field.name)] = parsed;
      }
    });
    return payload;
  };

  const reload = async () => {
    const data = await api.get<RecordShape[]>(config.endpoint);
    setRecords(data);
  };

  const handleSave = async () => {
    const payload = buildPayload();
    if (selectedId) {
      await api.put(`${config.endpoint}/${selectedId}`, payload);
    } else {
      await api.post(config.endpoint, payload);
    }
    await reload();
    setSelectedId(null);
    setFormState({});
  };

  const handleDelete = async () => {
    if (!selectedId) return;
    await api.del(`${config.endpoint}/${selectedId}`);
    await reload();
    setSelectedId(null);
    setFormState({});
  };

  return (
    <section className="section">
      <div className="section-header">
        <div>
          <h2>{config.label}</h2>
          <p>Manage {config.label} records.</p>
        </div>
        <button className="btn ghost" onClick={() => navigate("/admin")}>Back to admin</button>
      </div>

      <div className="panel">
        <div className="admin-layout">
          <div className="admin-form">
            <h3>{selectedId ? `Edit ${config.label} #${selectedId}` : `Create ${config.label}`}</h3>
            <form>
              {config.fields.map((field) => (
                <div className="form-field" key={field.name}>
                  <label>{field.name}</label>
                  {field.type === "enum" ? (
                    <select
                      className="input"
                      value={formState[field.name] ?? ""}
                      onChange={(e) => handleInput(field, e.target.value)}
                    >
                      <option value="">Select</option>
                      {enumOptions[field.options || "AddressType"].map((option) => (
                        <option key={option} value={option}>{option}</option>
                      ))}
                    </select>
                  ) : field.type === "lookup" ? (
                    <select
                      className="input"
                      value={formState[field.name] ?? ""}
                      onChange={(e) => handleInput(field, e.target.value)}
                    >
                      <option value="">Select</option>
                      {(lookupOptions[field.name] || []).map((item) => {
                        const labelKey = field.lookup?.labelKey || "name";
                        const label = item[labelKey] ?? item.id ?? "";
                        return (
                          <option key={String(item.id)} value={String(item.id)}>
                            {String(label)}
                          </option>
                        );
                      })}
                    </select>
                  ) : field.type === "bool" ? (
                    <select
                      className="input"
                      value={formState[field.name] ?? "true"}
                      onChange={(e) => handleInput(field, e.target.value)}
                    >
                      <option value="true">True</option>
                      <option value="false">False</option>
                    </select>
                  ) : (
                    <input
                      className="input"
                      type={field.type === "number" ? "number" : field.type === "datetime" ? "datetime-local" : "text"}
                      value={formState[field.name] ?? ""}
                      onChange={(e) => handleInput(field, e.target.value)}
                    />
                  )}
                </div>
              ))}
            </form>
            <div className="form-actions">
              <button className="btn primary" type="button" onClick={handleSave}>Save</button>
              <button className="btn ghost" type="button" onClick={() => { setSelectedId(null); setFormState({}); }}>Reset</button>
              <button className="btn danger" type="button" onClick={handleDelete} disabled={!selectedId}>Delete</button>
            </div>
          </div>
          <div className="admin-table">
            <div className="table">
              {!records.length && <div className="table-row"><span>No records found.</span></div>}
              {!!records.length && (
                <>
                  <div className="table-row header">
                    <span>Id</span>
                    {config.fields.map((f) => <span key={f.name}>{f.name}</span>)}
                    <span></span>
                  </div>
                  {records.map((record) => (
                    <div className="table-row" key={String(record.id)}>
                      <span>{record.id}</span>
                      {config.fields.map((f) => (
                        <span key={f.name}>{String(record[toCamel(f.name)] ?? "")}</span>
                      ))}
                      <button className="btn ghost" onClick={() => handleSelect(record)}>Edit</button>
                    </div>
                  ))}
                </>
              )}
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}
