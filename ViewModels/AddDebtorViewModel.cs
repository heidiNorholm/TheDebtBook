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
    public decimal NewDebtorAmount { get; set; }
    public int NewDebtorId { get; set; }
    public string NewDebtorName { get; set; }
    public ICommand AddDebtorCommand { get; set; }
    private int id = 0;

    // Properties and methods related to the Add Debtor Page
    public AddDebtorViewModel(MainPageViewModel mainPageViewModel)
    {
        this.mainPageViewModel = mainPageViewModel; // Initialize mainPageViewModel
        _database = mainPageViewModel.GetDataBase();
        AddDebtorCommand = new Command(async () => await AddNewDebtor());
    }


    public async Task AddNewDebtor()
    {
        var debtor = new Debtor()
        {
            AmountOwed = NewDebtorAmount,
            Id = NewDebtorId,
            Name = NewDebtorName
        };

        var inserted = await _database.AddDebtor(debtor);
        if (inserted != 0)
        {
            
            //mainPageViewModel.Debtors.Add(debtor);
            _database.AddDebtor(debtor);
            NewDebtorAmount = Decimal.Zero;
            NewDebtorId = id++;
            NewDebtorName = String.Empty;
            RaisePropertyChanged(nameof(NewDebtorAmount), nameof(NewDebtorId), nameof(NewDebtorName));
        }
    }
}