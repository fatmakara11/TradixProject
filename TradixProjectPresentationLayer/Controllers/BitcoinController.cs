using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TradixProject.DataAccessLayer.Repositories;

namespace TradixProjectPresentationLayer.Controllers
{
    public class BitcoinController : Controller
    {
        private readonly IBitcoinRepository _bitcoinRepository;

        public BitcoinController(IBitcoinRepository bitcoinRepository)
        {
            _bitcoinRepository = bitcoinRepository;
        }

        public IActionResult Index()
        {
            List<BitcoinPara> bitcoinParalar = _bitcoinRepository.GetActiveBitcoinData();
            return View(bitcoinParalar);
        }
    }
}
