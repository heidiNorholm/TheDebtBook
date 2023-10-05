// AddDebtorViewModel.cs
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
    public int NewDebtorId { get; set; }
    public string NewDebtorName { get; set; }
    public ICommand AddDebtorCommand { get; set; }
    private int id=0;

    // Properties and methods related to the Add Debtor Page
    public AddDebtorViewModel(MainPageViewModel mainPageViewModel)
    {
        this.mainPageViewModel = mainPageViewModel; // Initialize mainPageViewModel
        NewDebtorId = mainPageViewModel.ID;
        _database = mainPageViewModel.GetDataBase();
        AddDebtorCommand = new Command(async () => await AddNewDebtor());
        //mainPageViewModel.ID++;
    }


    public async Task AddNewDebtor()
    {
        //mainPageViewModel.ID++;
        var debtor = new Debtor()
        {
            AmountOwed = NewDebtorAmount,
            Id = NewDebtorId,
            Name = NewDebtorName
        };

        var transaction = new Transaction()
        {
            Amount = debtor.AmountOwed,
            Id = debtor.Id,
        };
        
        var inserted = await _database.AddDebtor(debtor);
        var insertValue=await _database.AddTransaction(transaction);
        if (inserted != 0)
        {

            //mainPageViewModel.Debtors.Add(debtor);
            //await _database.AddDebtor(debtor);
            //await _database.AddTransaction(transaction);

            RaisePropertyChanged(nameof(NewDebtorAmount), nameof(NewDebtorId), nameof(NewDebtorName));
            NewDebtorAmount = 0;
            id++;
            NewDebtorId = id;
            //NewDebtorId++;
            NewDebtorName = String.Empty;
        }
    }
}