import { FormEvent, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../auth";

export default function RegisterPage() {
  const { register } = useAuth();
  const navigate = useNavigate();
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const form = event.currentTarget;
    const formData = new FormData(form);
    const payload = {
      email: String(formData.get("email") || "").trim(),
      password: String(formData.get("password") || ""),
      phone: String(formData.get("phone") || "").trim() || null,
      isAdmin: String(formData.get("isAdmin") || "false") === "true"
    };
    setError(null);
    try {
      const user = await register(payload);
      navigate(user.isAdmin ? "/admin" : "/catalog");
    } catch {
      setError("Registration failed. Email may already exist.");
    }
  };

  return (
    <div className="form-card">
      <h2>Create account</h2>
      <p className="sub">Register to sync carts and unlock admin controls.</p>
      <form onSubmit={handleSubmit}>
        <div className="form-field">
          <label>Email</label>
          <input className="input" type="email" name="email" required />
        </div>
        <div className="form-field">
          <label>Phone</label>
          <input className="input" type="text" name="phone" />
        </div>
        <div className="form-field">
          <label>Password</label>
          <input className="input" type="password" name="password" required />
        </div>
        <div className="form-field">
          <label>Role</label>
          <select className="input" name="isAdmin">
            <option value="false">User</option>
            <option value="true">Admin</option>
          </select>
        </div>
        <button className="btn primary" type="submit">Register</button>
      </form>
      <div className="auth-links">
        <Link className="btn ghost" to="/login">I already have an account</Link>
      </div>
      {error && <p className="sub">{error}</p>}
    </div>
  );
}
