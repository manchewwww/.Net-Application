namespace AutoPartsShop.Entities
{
    public class ImportJobEntity
    {
        public long Id { get; set; }
        public long SupplierId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public string? StatsJson { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
