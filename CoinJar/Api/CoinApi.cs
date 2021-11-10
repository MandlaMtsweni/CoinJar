using CoinJar.Models;
using CoinJar.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Api
{
    public class CoinApi : ICoinApi
    {
        private readonly ICoinRepository _coinRepository;
        public decimal JarMaxVolume { get; private set; }
        public CoinApi(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
            this.JarMaxVolume = 42;
        }

        public async Task AddCoinAsync(Coin coin)
        {
            try
            {
                if (coin != null && coin.Volume < JarMaxVolume)
                {
                    await _coinRepository.AddCoinAsync(coin);
                    await _coinRepository.UpdateTotalAsync(coin.Amount);
                    // update total
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task GetTotalAmount()
        {
            await _coinRepository.GetTotalAmount();
        }
        public async Task Reset()
        {
            await _coinRepository.Reset();
        }

    }
}
