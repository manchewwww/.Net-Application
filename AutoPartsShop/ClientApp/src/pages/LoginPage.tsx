import { FormEvent, useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import { useAuth } from "../auth";

export default function LoginPage() {
  const { login } = useAuth();
  const navigate = useNavigate();
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const form = event.currentTarget;
    const formData = new FormData(form);
    const email = String(formData.get("email") || "").trim();
    const password = String(formData.get("password") || "");
    setError(null);
    try {
      const user = await login(email, password);
      navigate(user.isAdmin ? "/admin" : "/catalog");
    } catch {
      setError("Login failed. Check your credentials.");
    }
  };

  return (
    <div className="form-card">
      <h2>Sign in</h2>
      <p className="sub">Access your saved cart and order history.</p>
      <form onSubmit={handleSubmit}>
        <div className="form-field">
          <label>Email</label>
          <input className="input" type="email" name="email" required />
        </div>
        <div className="form-field">
          <label>Password</label>
          <input className="input" type="password" name="password" required />
        </div>
        <button className="btn primary" type="submit">Login</button>
      </form>
      <div className="auth-links">
        <Link className="btn ghost" to="/register">Create account</Link>
        <Link className="btn ghost" to="/catalog">Continue as guest</Link>
      </div>
      {error && <p className="sub">{error}</p>}
    </div>
  );
}
