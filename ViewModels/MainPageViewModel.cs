// MainPageViewModel.cs
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using TheDebtBook.Data;
using System.Xml.Linq;
using TheDebtBook.Data;

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
            
            // Sample data (replace with actual data retrieval)
            Debtors = new ObservableCollection<Debtor>
            {
                new Debtor { Name = "John Doe", AmountOwed = 100.00M },
                new Debtor { Name = "Alice Smith", AmountOwed = 50.00M },
                new Debtor { Name = "Bob Johnson", AmountOwed = -25.00M } // Negative amount indicates creditor
                // Add more debtors as needed
            };
        }
    }
}
