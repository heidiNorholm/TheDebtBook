// DebtorDetailsViewModel.cs
using DebtBook.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TheDebtBook.Data;

public class DebtorDetailsViewModel : BaseViewModel
{
    // Properties and methods related to the Debtor Details Page

    //public double Value { get; set; }
    public double NewValue { get; set; }
    public Debtor debtor;

    public MainPageViewModel mainPageViewModel;
    internal DataBase _database;
    private ObservableCollection<Transaction> transactions;


    public ICommand AddValueCommand { get; set; }

    public DebtorDetailsViewModel(MainPageViewModel mainPageViewModel,Debtor selectedDebtor)
    {
        this.mainPageViewModel= mainPageViewModel;
        debtor = selectedDebtor;
        _database = mainPageViewModel.GetDataBase();
        Transactions = new ObservableCollection<Transaction>();
        _= LoadTransactionsAsync(selectedDebtor.Id);
        AddValueCommand = new Command(async () => await AddValue());
        TotalAmount(selectedDebtor.Id);
    }

    public ObservableCollection<Transaction> Transactions
    {
        get { return transactions; }
        set { SetProperty(ref transactions, value); }
    }



    //public DebtorDetailsViewModel(Debtor selectedDebtor)
    //{
    //    debtor=selectedDebtor;
    //}

    public async Task AddValue()
    {
        var transaction = new Transaction()
        {
            Amount = NewValue,
            Id = debtor.Id,
        };
        var insertValue = await _database.AddTransaction(transaction);
        if (insertValue != 0)
        {
            await _database.AddTransaction(transaction);
            RaisePropertyChanged(nameof(NewValue), nameof(debtor.Id));
        }
    }


    // Lave metode til at udregne totalAmount
        private double TotalAmount(int id)
        {
            return 0;
        }


    // Metode til at loade de transactions der er for en given person i DB
    public async Task LoadTransactionsAsync(int id)
    {
        try
        {
            List<Transaction> transactionsFromDatabase = await _database.GetTransactions(id); // Assuming GetDebtor is an async method.

            foreach (var transaction in transactionsFromDatabase)
            {
                Transactions.Add(transaction);
                OnPropertyChanged();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }


}