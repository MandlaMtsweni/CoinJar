using CoinJar.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.DataAccessManagement
{
    public class DapperAdapter : IDapperAdapter
    {
        private string _dbConnection;

        public DapperAdapter(IConfiguration Configuration)
        {
            DbConnection = Configuration.GetConnectionString("DefaultConnection");
        }

        public string DbConnection
        {
            get
            {
                return _dbConnection;
            }

            set
            {
                _dbConnection = value;
            }
        }

        public async Task<int> ExecuteAsync(string function, object param = null)
        {
            using (var dbConnection = new MySqlConnection(DbConnection))
            {
                dbConnection.Open();
                var result = await dbConnection.ExecuteAsync(function, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<T> Query<T>(string function, object param = null)
        {
            using (var dbConnection = new MySqlConnection(DbConnection))
            {
                dbConnection.Open();
                var result = dbConnection.Query<T>(function, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string function, object param = null)
        {
            using (var dbConnection = new MySqlConnection(DbConnection))
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<T>(function, param, commandType: CommandType.StoredProcedure, commandTimeout: 1000);
                return result;
            }
        }

        public async Task<IEnumerable<T>> RunSqlAsync<T>(string sql)
        {
            using (var dbConnection = new MySqlConnection(DbConnection))
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<T>(sql, null, commandType: CommandType.Text);
                return result;
            }
        }

        public async Task ExecuteSqlAsync(string sql)
        {
            using (var dbConnection = new MySqlConnection(DbConnection))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync(sql, null, commandType: CommandType.Text);
            }
        }
    }
}
