using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Data
{
   using TheDebtBook;
   using SQLite;
    using SQLitePCL;

    internal class DataBase
    {
        private readonly SQLiteAsyncConnection _connection;

        public DataBase()
        {
            var dataDir = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDir, "TheDebtBook31.db");

            string _dbEncryptionKey = SecureStorage.GetAsync("dbKey").Result;

            if (string.IsNullOrEmpty(_dbEncryptionKey))
            {
                Guid g = new Guid();
                _dbEncryptionKey = g.ToString();
                SecureStorage.SetAsync("dbKey", _dbEncryptionKey);
            }

            var dbOptions = new SQLiteConnectionString(databasePath, true, key: _dbEncryptionKey);

            _connection = new SQLiteAsyncConnection(dbOptions);

            _ = Initialise();
        }

        private async Task Initialise()
        {
            await _connection.CreateTableAsync<Debtor>();
            await _connection.CreateTableAsync<Transaction>();
        }

        public async Task<List<Debtor>> GetDebtors()
        {
            return await _connection.Table<Debtor>().ToListAsync();
        }

        public async Task<Debtor> GetDebtor(int id)
        {
            var query = _connection.Table<Debtor>().Where(t => t.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> AddDebtor(Debtor item)
        {
            return await _connection.InsertAsync(item);
        }


        public async Task<int> AddTransaction(Transaction item)
        {
            return await _connection.InsertAsync(item);
        }

        public async Task<List<Transaction>> GetTransactions(int id)
        {
            //var query = _connection.Table<Transaction>().Where(t => t.DebtorId == id);
            //return await _connection.Table<Transaction>().ToListAsync();
            return await _connection.Table<Transaction>().Where(t => t.DebtorId == id).ToListAsync();
        }

    }
}
