import { NavLink, Outlet, useNavigate } from "react-router-dom";
import { useAuth } from "../auth";

export default function Layout() {
  const { user, logout } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate("/login");
  };

  return (
    <>
      <div className="bg">
        <div className="orb orb-a"></div>
        <div className="orb orb-b"></div>
        <div className="grid"></div>
      </div>
      <header className="topbar">
        <div className="logo">
          <span className="logo-mark">AP</span>
          <span className="logo-text">AutoParts</span>
        </div>
        <nav className="nav">
          <NavLink className="nav-link" to="/">Home</NavLink>
          <NavLink className="nav-link" to="/catalog">Catalog</NavLink>
          <NavLink className="nav-link" to="/cart">Cart</NavLink>
          <NavLink className="nav-link" to="/orders">Orders</NavLink>
          {user?.isAdmin && <NavLink className="nav-link" to="/admin">Admin</NavLink>}
        </nav>
        <div className="cta">
          {user ? (
            <span>
              {user.isAdmin ? "Admin" : "User"} · {user.email}
              <button className="btn ghost" style={{ marginLeft: 12 }} onClick={handleLogout}>
                Logout
              </button>
            </span>
          ) : (
            "Guest"
          )}
        </div>
      </header>
      <main className="container">
        <Outlet />
      </main>
      <footer className="footer">
        <span>AutoParts Shop</span>
        <span>{user ? user.email : "Guest"}</span>
      </footer>
    </>
  );
}
