using CoinJar.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Models
{
    public interface ICoinApi
    {
        Task AddCoinAsync(Coin coin);
        Task Reset();
        Task GetTotalAmount();
    }
}
