import { useEffect, useState } from "react";
import { api, getLocalCart, getUser, setLocalCart } from "../api";

type CartItem = {
  partId: number;
  qty: number;
  partName: string;
  sku: string;
};

type Part = { id: number; name: string; sku: string };

export default function CartPage() {
  const [items, setItems] = useState<CartItem[]>([]);
  const [isServer, setIsServer] = useState(false);

  const loadCart = async () => {
    const user = getUser();
    if (user) {
      try {
        const cart = await api.get<{ items: CartItem[] }>("/api/me/cart");
        setItems(cart.items);
        setIsServer(true);
        return;
      } catch (err) {
        console.warn("Server cart failed, using local", err);
      }
    }

    const local = getLocalCart();
    const parts = await api.get<Part[]>("/api/parts");
    const map = new Map(parts.map((p) => [p.id, p]));
    const mapped = local.map((item) => {
      const part = map.get(item.partId) || { id: item.partId, name: "Unknown", sku: "-" };
      return { partId: item.partId, qty: item.qty, partName: part.name, sku: part.sku };
    });
    setItems(mapped);
    setIsServer(false);
  };

  useEffect(() => {
    loadCart().catch(console.error);
  }, []);

  const updateQty = async (partId: number, qty: number) => {
    const safeQty = Math.max(1, qty);
    if (isServer) {
      try {
        await api.post("/api/me/cart/items", { partId, qty: safeQty });
        await loadCart();
        return;
      } catch (err) {
        console.warn("Server cart failed, using local", err);
      }
    }
    const local = getLocalCart();
    const item = local.find((i) => i.partId === partId);
    if (item) item.qty = safeQty;
    setLocalCart(local);
    await loadCart();
  };

  const removeItem = async (partId: number) => {
    if (isServer) {
      try {
        await api.del(`/api/me/cart/items/${partId}`);
        await loadCart();
        return;
      } catch (err) {
        console.warn("Server cart failed, using local", err);
      }
    }
    const local = getLocalCart().filter((i) => i.partId !== partId);
    setLocalCart(local);
    await loadCart();
  };

  const clearCart = async () => {
    if (isServer) {
      try {
        await api.del("/api/me/cart");
        await loadCart();
        return;
      } catch (err) {
        console.warn("Server cart failed, using local", err);
      }
    }
    setLocalCart([]);
    await loadCart();
  };

  return (
    <section className="section" id="cart">
      <div className="section-header">
        <div>
          <h2>Your cart</h2>
          <p>Saved for signed-in users, local for guests.</p>
        </div>
        <button className="btn ghost" onClick={clearCart}>Clear cart</button>
      </div>
      <div className="panel">
        <div className="table">
          {!items.length && <div className="table-row"><span>Your cart is empty.</span></div>}
          {!!items.length && (
            <>
              <div className="table-row header">
                <span>Part</span>
                <span>SKU</span>
                <span>Qty</span>
                <span>Actions</span>
              </div>
              {items.map((item) => (
                <div className="table-row" key={item.partId}>
                  <span>{item.partName}</span>
                  <span>{item.sku}</span>
                  <input
                    className="input"
                    type="number"
                    min={1}
                    value={item.qty}
                    onChange={(e) => updateQty(item.partId, Number(e.target.value))}
                  />
                  <button className="btn ghost" onClick={() => removeItem(item.partId)}>Remove</button>
                </div>
              ))}
            </>
          )}
        </div>
      </div>
    </section>
  );
}
