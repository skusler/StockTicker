using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace StockTicker
{
    class Program
    {
        private static Timer timer;
        private decimal lastPrice;
        private decimal percentDifference = 0;
        private static int MillisecondInterval = 60000;

        static void Main(string[] args)
        {
            timer = new Timer(MillisecondInterval);
            timer.Elapsed += HandleTimer;
            SetTimer();
            DisplayTickerPrice();

            // Easy way to make this into a service that runs until the window is closed.
            while (true) { }
        }

        private static void HandleTimer(Object source, ElapsedEventArgs e)
        {
            DisplayTickerPrice();
        }

        public static void DisplayTickerPrice()
        {
            // If you want more than one seperate them by , with no spaces.
            const string tickers = "AMD,AAPL,BABA,BIDU,SQ,CAT";

            string json;

            using (WebClient web = new WebClient())
            {
                string url = $"http://finance.google.com/finance/info?client=ig&q=NASDAQ%3A{tickers}";
                json = web.DownloadString(url);
            }

            json = json.Replace("//", "");

            JArray jsonArray = JArray.Parse(json);

            foreach (JToken item in jsonArray)
            {
                JToken ticker = item.SelectToken("t");
                JToken price = (decimal)item.SelectToken("l");

                Console.WriteLine($"{ticker.ToString().PadRight(4, ' ')} : {price}");
            }

            SetTimer();
        }

        private static void SetTimer()
        {
            timer.Interval = MillisecondInterval;
            timer.Start();
        }
    }
}
