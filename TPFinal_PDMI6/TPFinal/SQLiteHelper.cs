using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TPFinal
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Mercadoria>().Wait();
        }

        //Insert and Update new record
        public Task<int> SaveItemAsync(Mercadoria prod)
        {
            if (prod.Id != 0)
            {
                return db.UpdateAsync(prod);
            }
            else
            {
                return db.InsertAsync(prod);
            }
        }

        //Delete
        public Task<int> DeleteItemAsync(Mercadoria prod)
        {
            return db.DeleteAsync(prod);
        }

        //Read All Items
        public Task<List<Mercadoria>> GetItemsAsync()
        {
            return db.Table<Mercadoria>().ToListAsync();
        }


        //Read Item
        public Task<Mercadoria> GetItemAsync(int Id)
        {
            return db.Table<Mercadoria>().Where(i => i.Id == Id).FirstOrDefaultAsync();
        }
    }
}
