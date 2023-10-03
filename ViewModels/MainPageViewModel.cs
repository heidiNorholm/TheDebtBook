// MainPageViewModel.cs
using System.Collections.ObjectModel;
using TheDebtBook.Data;


namespace DebtBook.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Debtor> debtors;
        internal DataBase _database;

        //public Debtor debtor;

        public ObservableCollection<Debtor> Debtors
        {
            get { return debtors; }
            set { SetProperty(ref debtors, value); }
        }

        public MainPageViewModel()
        {
            _database = new DataBase();
            Debtors=new ObservableCollection<Debtor>();
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

                    // En prøve
                    OnPropertyChanged();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        public async Task LoadDebtorAsync()
        {
            try
            {
                var debtorFromDatabase = await _database.GetDebtors(); // Assuming GetDebtors is an async method.
                Debtor debtor = debtorFromDatabase.Last();
  
                    Debtors.Add(debtor);

                    // En prøve
                    OnPropertyChanged();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        internal DataBase GetDataBase()
        {
            return _database;
        }

    }
}
