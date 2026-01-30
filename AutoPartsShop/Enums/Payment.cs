namespace AutoPartsShop.Enums
{
    public enum PaymentProvider
    {
        STRIPE
    }

    public enum PaymentStatus
    {
        PENDING,
        COMPLETED,
        FAILED,
        REFUNDED
    }
}