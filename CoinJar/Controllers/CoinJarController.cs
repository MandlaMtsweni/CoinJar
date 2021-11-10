using CoinJar.Models;
using CoinJar.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CoinJarController : Controller
    {
        private readonly ILogger<CoinJarController> _logger;
        private readonly ICoinApi _coinApi;
        public CoinJarController(ILogger<CoinJarController> logger, ICoinApi coinApi)
        {
            _logger = logger;
            _coinApi = coinApi;
        }

        [HttpPost("Coin")]
        public void Coin([FromBody] Coin coin)
        {    
            _coinApi.AddCoinAsync(coin);            
        }

        [HttpGet("TotalAmount")]
        public void GetTotalAmount()
        {
            _coinApi.GetTotalAmount();
        }

        [HttpPost("Reset")]
        public void Reset()
        {
            _coinApi.Reset();
        }

    }
}
