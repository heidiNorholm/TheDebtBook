// MainPageViewModel.cs
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using TheDebtBook.Data;
using System.Xml.Linq;

namespace DebtBook.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Debtor> debtors;
        private readonly DataBase _database;


        public ObservableCollection<Debtor> Debtors
        {
            get { return debtors; }
            set { SetProperty(ref debtors, value); }
        }

        public MainPageViewModel()
        {
            _database = new DataBase();
            _ = LoadDebtorsAsync();
        }

        public async Task LoadDebtorsAsync()
        {
            try
            {
                var debtorsFromDatabase = await _database.GetDebtors(); // Assuming GetDebtors is an async method.

                foreach (var debtor in debtorsFromDatabase)
                {
                    Debtors.Add(debtor);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately, e.g., log or display an error message.
            }
        }
    }
}
