using TheDebtBook.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DebtBook.ViewModels;
using System.Windows.Input;

public class AddDebtorViewModel : BaseViewModel
{
    public MainPageViewModel mainPageViewModel;
    internal DataBase _database;
    public double NewDebtorAmount { get; set; }
    public string NewDebtorName { get; set; }
    public ICommand AddDebtorCommand { get; set; }

    public AddDebtorViewModel(MainPageViewModel mainPageViewModel)
    {
        this.mainPageViewModel = mainPageViewModel;
        _database = mainPageViewModel.GetDataBase();
        AddDebtorCommand = new Command(async () => await AddNewDebtor());
    }

    public async Task AddNewDebtor()
    {
        var debtor = new Debtor()
        {
            AmountOwed = NewDebtorAmount,
            Name = NewDebtorName
        };
        var inserted = await _database.AddDebtor(debtor);
        var transaction = new Transaction()
        {
            Amount = debtor.AmountOwed,
            DebtorId = debtor.Id,
        };
        var insertValue=await _database.AddTransaction(transaction);
        if (inserted != 0)
        {
            RaisePropertyChanged(nameof(NewDebtorAmount), nameof(NewDebtorName));
            NewDebtorAmount = 0;
            NewDebtorName = String.Empty;
        }
    }
}