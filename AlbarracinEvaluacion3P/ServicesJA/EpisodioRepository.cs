using AlbarracinEvaluacion3P.ModelsJA;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbarracinEvaluacion3P.ServicesJA
{
    public class EpisodioRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public EpisodioRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<EpisodioJA>().Wait();
        }

        public Task<List<EpisodioJA>> GetSavedEpisodeAsync()
        {
            return _database.Table<EpisodioJA>().ToListAsync();
        }
        public Task<int> SaveEpisodeAsync(EpisodioJA episode)
        {
            return _database.InsertAsync(episode);
        }
    }
}
