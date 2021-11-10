using CoinJar.Models;
using CoinJar.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar
{
    public class CoinRepository : ICoinRepository
    {
        private readonly IDapperAdapter _dapperAdapter;

        private readonly IConfiguration _configuration;

        public CoinRepository(IDapperAdapter dapperAdapter, IConfiguration configuration)
        {
            _dapperAdapter = dapperAdapter;
            _configuration = configuration;
        }

        public async Task AddCoinAsync(Coin coin)
        {
            await _dapperAdapter.QueryAsync<Coin>("coin_jar_add_coin_new", new
            {
                p_amount = coin.Amount,
                p_volume = coin.Volume,
            });
        }

        public async Task<decimal> GetTotalAmount()
        {
            var result = await _dapperAdapter.QueryAsync<decimal>("coin_jar_get_total_amount");
            return result.FirstOrDefault();
        }

        public async Task Reset()
        {
            await _dapperAdapter.QueryAsync<dynamic>("coin_jar_get_reset");
        }

        public async Task UpdateTotalAsync(decimal amount)
        {
            await _dapperAdapter.QueryAsync<decimal>("coin_jar_update_total", new { p_amount = amount });
        }
    }
}
