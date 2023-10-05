using SQLite;

public class Transaction
{
    [PrimaryKey, AutoIncrement]

    public int TransactionId { get; set; }

    [Indexed]
    public int DebtorId { get; set; }
    public double Amount { get; set; }
    //public DateTime TransactionDate { get; set; }
}