// DebtorDetailsViewModel.cs
using DebtBook.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;

public class DebtorDetailsViewModel : BaseViewModel
{
    // Properties and methods related to the Debtor Details Page

    private double newValue;
    public double NewValue 
    {
        get
        { 
            return newValue;
        }
        set
        {
            if(value !=newValue)
            {
                newValue = value;
                RaisePropertyChanged(nameof(NewValue));
            }
        }
    }
    public DebtorDTO Debtor { get; set; }
    public string Name { get; set; }

    private double totalAmount;
    public double TotalAmount
    { get
        { 
            return totalAmount; 
        }
        set 
        { 
            totalAmount = value;
            OnPropertyChanged(nameof(TotalAmount));
        }
    }

    public MainPageViewModel mainPageViewModel;
    internal DataBase _database;
    private ObservableCollection<Transaction> transactions;
    public ICommand AddValueCommand { get; set; }

    public ObservableCollection<Transaction> Transactions
    {
        get { return transactions; }
        set { SetProperty(ref transactions, value); }
    }

    public DebtorDetailsViewModel(MainPageViewModel mainPageViewModel,DebtorDTO selectedDebtor)
    {
        this.mainPageViewModel= mainPageViewModel;
        Debtor = selectedDebtor;
        Name=Debtor.Name;
        TotalAmount = Debtor.AmountOwed;
        _database = mainPageViewModel.GetDataBase();
        Transactions = new ObservableCollection<Transaction>();
        _ = LoadTransactionsAsync(selectedDebtor.Id);
        AddValueCommand = new Command(async () => await AddValue());
    }

    public async Task AddValue()
    {
        var transaction = new Transaction()
        {
            Amount = NewValue,
            DebtorId = Debtor.Id,
        };
        var insertValue = await _database.AddTransaction(transaction);
        if (insertValue != 0)
        {
            RaisePropertyChanged(nameof(NewValue));
        }
    }

    public async Task LoadTransactionsAsync(int id)
    {
        try
        {
            List<Transaction> transactionsFromDatabase = await _database.GetTransactions(id); // Assuming GetDebtor is an async method.

            foreach (var transaction in transactionsFromDatabase)
            {
                Transactions.Add(transaction);
                NewValue = transaction.Amount;
                OnPropertyChanged();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}