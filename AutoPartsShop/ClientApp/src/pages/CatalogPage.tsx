import { useEffect, useMemo, useState } from "react";
import { api, getLocalCart, getUser, setLocalCart } from "../api";

type Part = {
  id: number;
  sku: string;
  brandId: number;
  categoryId: number;
  name: string;
  description?: string | null;
  isActive: boolean;
  weightKg?: number | null;
};

export default function CatalogPage() {
  const [parts, setParts] = useState<Part[]>([]);
  const [query, setQuery] = useState("");
  const [filter, setFilter] = useState("all");

  useEffect(() => {
    api.get<Part[]>("/api/parts").then(setParts).catch(console.error);
  }, []);

  const filtered = useMemo(() => {
    let data = parts;
    if (filter === "active") {
      data = data.filter((p) => p.isActive);
    } else if (filter === "inactive") {
      data = data.filter((p) => !p.isActive);
    }
    if (query) {
      const q = query.toLowerCase();
      data = data.filter((p) => p.name.toLowerCase().includes(q) || p.sku.toLowerCase().includes(q));
    }
    return data;
  }, [parts, query, filter]);

  const addToCart = async (partId: number) => {
    const user = getUser();
    if (user) {
      try {
        const current = await api.get<{ items: { partId: number; qty: number }[] }>("/api/me/cart");
        const existing = current.items.find((item) => item.partId === partId);
        const qty = existing ? existing.qty + 1 : 1;
        await api.post("/api/me/cart/items", { partId, qty });
        return;
      } catch (err) {
        console.warn("Server cart failed, using local.", err);
      }
    }
    const cart = getLocalCart();
    const existing = cart.find((item) => item.partId === partId);
    if (existing) {
      existing.qty += 1;
    } else {
      cart.push({ partId, qty: 1 });
    }
    setLocalCart(cart);
  };

  return (
    <section className="section" id="catalog">
      <div className="section-header">
        <div>
          <h2>Catalog</h2>
          <p>Search and add parts to your cart.</p>
        </div>
        <div className="filters">
          <input
            className="input"
            type="search"
            value={query}
            onChange={(e) => setQuery(e.target.value)}
            placeholder="Search by SKU or name"
          />
          <select className="input" value={filter} onChange={(e) => setFilter(e.target.value)}>
            <option value="all">All</option>
            <option value="active">Active only</option>
            <option value="inactive">Inactive</option>
          </select>
        </div>
      </div>
      <div className="card-grid">
        {filtered.map((part) => (
          <div className="card" key={part.id}>
            <div>
              <h3>{part.name}</h3>
              <p>{part.description || "No description"}</p>
            </div>
            <div className="meta">
              <span>SKU {part.sku}</span>
              <span>{part.isActive ? "Active" : "Inactive"}</span>
            </div>
            <button className="btn primary" onClick={() => addToCart(part.id)}>Add to cart</button>
          </div>
        ))}
      </div>
    </section>
  );
}
