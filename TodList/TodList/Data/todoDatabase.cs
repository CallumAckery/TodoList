using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodList.Model;

namespace TodList.Data
{
    public class todoDatabase
    {
        static SQLiteAsyncConnection database;

        /* Database Constructor */
        public todoDatabase(string dbpath)
        {
            database = new SQLiteAsyncConnection(dbpath);
        }

        /* Get the Item from database */
        public async Task<List<TodoList>> GetNotesAsync()
        {
            return await database.Table<TodoList>().ToListAsync();
        }

        /* Insert Items in to db*/
        public async Task<int> InsertItems(TodoList td)
        {
            await database.ExecuteScalarAsync<TodoList>("INSERT INTO [items] (notes) VALUES(?)", td.Notes);
            int ret = 1;
            return ret;
        }

        public async Task<int> UpdateItems(TodoList td)
        {
            await database.ExecuteScalarAsync<TodoList>("UPDATE [items] SET NOTES = ? WHERE ID = ?",td.Notes, td.Id);
            int ret = 1;
            return ret;
        }

        public async Task<int> DeleteItems(TodoList td)
        {
            await database.ExecuteScalarAsync<TodoList>("DELETE FROM [items] WHERE id = ?", td.Id);
            int ret = 1;
            return ret;
        }
    }
}
