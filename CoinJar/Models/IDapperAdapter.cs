using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Models
{
    public interface IDapperAdapter
    {
        string DbConnection { get; set; }

        Task<int> ExecuteAsync(string function, object param = null);

        IEnumerable<T> Query<T>(string function, object param = null);

        Task<IEnumerable<T>> QueryAsync<T>(string function, object param = null);

        Task<IEnumerable<T>> RunSqlAsync<T>(string sql);

        Task ExecuteSqlAsync(string sql);
    }
}
