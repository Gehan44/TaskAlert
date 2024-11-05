using SQLite;
using TaskAlert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAlert.Data
{
    internal class ActivityDatabase
    {
        SQLiteAsyncConnection _database;

        async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(
                Constants.DatabasePath,
                Constants.Flags);

            await _database.CreateTableAsync<Models.Activity>();
        }

        public async Task<List<Models.Activity>> GetActivitiesAsync()
        {
            await Init();
            return await _database.Table<Models.Activity>()
                .ToListAsync();
        }
        public async Task<List<Models.Activity>> GetActivitiesAsync(int page)
        {
            await Init();
            return await _database.Table<Models.Activity>()
                .Skip((page - 1) * 20)
                .Take(20)
                .ToListAsync();
        }
        public async Task<Models.Activity> GetActivityAsync(int pTaskId)
        {
            await Init();
            return await _database
                .Table<Models.Activity>()
                .Where(z => z.ID == pTaskId)
                .FirstOrDefaultAsync();
        }
        public async Task<int> SaveActivityAsync(Models.Activity pTask)
        {
            await Init();
            if (pTask.ID != 0)
            {
                return await _database.UpdateAsync(pTask);
            }
            else
            {
                return await _database.InsertAsync(pTask);
            }
        }
        public async Task<int> DeleteActivityAsync(Models.Activity pDelTask)
        {
            await Init();
            return await _database.DeleteAsync(pDelTask);
        }
    }
}
