public class Transaction
{
    public int Id { get; set; }
    public int DebtorId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
}