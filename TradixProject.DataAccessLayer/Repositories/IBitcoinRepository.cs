using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TradixProject.DataAccessLayer.Repositories
{
    public interface IBitcoinRepository
    {
        List<BitcoinPara> GetActiveBitcoinData();
    }
}
