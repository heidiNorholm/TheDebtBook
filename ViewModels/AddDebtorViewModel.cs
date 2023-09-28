// AddDebtorViewModel.cs
using TheDebtBook.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DebtBook.ViewModels;
using System.Windows.Input;

public class AddDebtorViewModel : BaseViewModel
{
    private MainPageViewModel mainPageViewModel;
    private readonly DataBase _database;
    public decimal NewDebtorAmount { get; set; }
    public int NewDebtorId { get; set; }
    public string NewDebtorName { get; set; }
    public ICommand AddDebtorCommand { get; set; }
    private int id = 0;

    // Properties and methods related to the Add Debtor Page
    public AddDebtorViewModel()
    {
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
            
            mainPageViewModel.Debtors.Add(debtor);
            NewDebtorAmount = Decimal.Zero;
            NewDebtorId = id++;
            NewDebtorName = String.Empty;
            RaisePropertyChanged(nameof(NewDebtorAmount), nameof(NewDebtorId), nameof(NewDebtorName));
        }
    }

}