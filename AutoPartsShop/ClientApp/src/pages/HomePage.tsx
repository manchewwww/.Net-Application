import { Link } from "react-router-dom";

export default function HomePage() {
  return (
    <section className="hero">
      <div className="hero-copy">
        <p className="eyebrow">Precision catalog</p>
        <h1>Everything your backend supports, now in React.</h1>
        <p className="sub">Browse parts, build a cart, and manage inventory with admin access.</p>
        <div className="hero-actions">
          <Link className="btn primary" to="/catalog">Browse catalog</Link>
          <Link className="btn ghost" to="/login">Sign in</Link>
          <Link className="btn secondary" to="/register">Create account</Link>
        </div>
      </div>
      <div className="hero-card">
        <div className="hero-card-header">
          <span>Live access</span>
          <span className="pill">UI + API</span>
        </div>
        <p className="sub">Authenticate to persist cart data in the database. Admins unlock all CRUD pages.</p>
      </div>
    </section>
  );
}
