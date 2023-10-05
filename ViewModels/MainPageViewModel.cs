// MainPageViewModel.cs
using System.Collections.ObjectModel;
using System.Transactions;
using System.Windows.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;

namespace DebtBook.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<DebtorDTO> debtors;
        internal DataBase _database;
        private ObservableCollection<Transaction> transactions;






        //public ICommand TotalAmountCommand { get; set; }

        public ObservableCollection<Transaction> Transactions
        {
            get { return transactions; }
            set { SetProperty(ref transactions, value); }
        }
        //public Debtor debtor;

        public ObservableCollection<DebtorDTO> Debtors
        {
            get { return debtors; }
            set { SetProperty(ref debtors, value); }
        }

        public MainPageViewModel()
        {
            _database = new DataBase();
            Debtors=new ObservableCollection<DebtorDTO>();
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
                    var debtorDTO = new DebtorDTO();
                    debtorDTO.AmountOwed = debtor.AmountOwed;
                    debtorDTO.Id = debtor.Id;
                    debtorDTO.Name= debtor.Name;
                    Debtors.Add(debtorDTO);

                    // En prøve
                    OnPropertyChanged();

                }
                _ = TotalAmountForAllDebtors();

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

                var debtorDTO = new DebtorDTO();
                debtorDTO.AmountOwed = debtor.AmountOwed;
                debtorDTO.Id = debtor.Id;
                debtorDTO.Name = debtor.Name;

                Debtors.Add(debtorDTO);

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
                            if (transaction.DebtorId == id)
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



        public async Task TotalAmountForAllDebtors()
        {
            try
            {
                foreach (var debtor in Debtors)
                {
                    double totalAmount = 0;
                    List<Transaction> transactionsFromDatabase = await _database.GetTransactions(debtor.Id); // Assuming GetDebtor is an async method.

                        foreach (var transaction in transactionsFromDatabase)
                        {
                            if (transaction.DebtorId == debtor.Id)
                            {
                                totalAmount += transaction.Amount;
                            }
                        }
                        debtor.AmountOwed = totalAmount;

                        RaisePropertyChanged(nameof(debtor.AmountOwed));

                        OnPropertyChanged();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

    }
}
