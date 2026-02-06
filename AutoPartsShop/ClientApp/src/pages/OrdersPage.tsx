export default function OrdersPage() {
  return (
    <section className="section">
      <div className="section-header">
        <div>
          <h2>Orders</h2>
          <p>Order tracking will appear here once checkout is enabled.</p>
        </div>
        <span className="badge">Coming soon</span>
      </div>
      <div className="panel empty">
        <p>No orders yet.</p>
      </div>
    </section>
  );
}
