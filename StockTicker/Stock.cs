using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTicker
{
    public class Stock
    {
        public string Ticker { get; set; }
        public string Exchange { get; set; }
        public decimal LastPrice { get; set; }
        public DateTime LastTradeTime { get; set; }
        public decimal Price { get; set; }
        public DateTime LastTradeTimeFormatted { get; set; }
        public DateTime LastTradeDateTime { get; set; }
        public decimal Change { get; set; }
        public decimal ChangePercentage { get; set; }
        public decimal AfterHoursLastPrice { get; set; }
        public DateTime AfterHoursLastTradeTimeFormatted { get; set; }
        public decimal Dividend { get; set; }
        public decimal DividendYield { get; set; }

    }
}
