using DebtBook.ViewModels;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Debtor
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public double AmountOwed { get; set; }
}