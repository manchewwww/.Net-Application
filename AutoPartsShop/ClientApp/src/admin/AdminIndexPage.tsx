import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { adminEntities } from "./AdminConfig";
import { useAuth } from "../auth";

export default function AdminIndexPage() {
  const { user } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    if (!user || !user.isAdmin) {
      navigate("/login");
    }
  }, [user, navigate]);

  if (!user || !user.isAdmin) {
    return null;
  }

  return (
    <section className="section">
      <div className="section-header">
        <div>
          <h2>Entities</h2>
          <p>Select a dataset to manage.</p>
        </div>
      </div>
      <div className="card-grid">
        {adminEntities.map((entity) => (
          <div className="card" key={entity.key}>
            <h3>{entity.label}</h3>
            <p>{entity.endpoint}</p>
            <button className="btn primary" onClick={() => navigate(`/admin/${entity.key}`)}>
              Open
            </button>
          </div>
        ))}
      </div>
    </section>
  );
}
