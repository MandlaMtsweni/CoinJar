using CoinJar.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Models
{
    public interface ICoinRepository
    {
        Task AddCoinAsync(Coin coin);
        Task UpdateTotalAsync(decimal amount);
        Task Reset();
        Task<decimal> GetTotalAmount();
    }
}
