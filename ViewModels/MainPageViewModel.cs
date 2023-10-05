// MainPageViewModel.cs
using System.Collections.ObjectModel;
using System.Transactions;
using System.Windows.Input;
using TheDebtBook.Data;


namespace DebtBook.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Debtor> debtors;
        internal DataBase _database;
        private ObservableCollection<Transaction> transactions;

        // prøve
        public int ID { get; set; } = 0;
        //



        //public ICommand TotalAmountCommand { get; set; }

        public ObservableCollection<Transaction> Transactions
        {
            get { return transactions; }
            set { SetProperty(ref transactions, value); }
        }
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
            Transactions=new ObservableCollection<Transaction>();
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


        // Lave metode til at udregne totalAmount
        public async Task TotalAmount(int id)
        {
            double totalAmount = 0;
            try
            {
                foreach (var debtor in Debtors)
                {
                    if (debtor.Id == id)
                    {
                        List<Transaction> transactionsFromDatabase = await _database.GetTransactions(id); // Assuming GetDebtor is an async method.

                        foreach (var transaction in transactionsFromDatabase)
                        {
                            if (transaction.Id == id)
                            {
                                totalAmount += transaction.Amount;
                            }
                        }
                        debtor.AmountOwed = totalAmount;

                        // Prøve
                        RaisePropertyChanged(nameof(debtor.AmountOwed));
                        //


                        OnPropertyChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

    }
}
