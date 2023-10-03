// DebtorDetailsViewModel.cs
using DebtBook.ViewModels;

public class DebtorDetailsViewModel : BaseViewModel
{
    // Properties and methods related to the Debtor Details Page

    public double Value { get; set; }
    public Debtor debtor;


    public DebtorDetailsViewModel(Debtor selectedDebtor)
    {
        debtor=selectedDebtor;
    }

    public async Task AddValue()
    {
        var transaction = new Transaction()
        {
            Amount = Value,
            Id = debtor.Id,
        };

    }


    // Lave metode til at udregne totalAmount
        private double TotalAmount(int id)
        {
            return 0;
        }


}