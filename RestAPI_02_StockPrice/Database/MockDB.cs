using RestAPI_02_StockPrice.Models;

namespace RestAPI_02_StockPrice.Database
{

    public class MockDB : IRepository
    {
        //---------------------------------
        //Initialise some mock data
        private List<StockListing> listings =
            new List<StockListing>()
            {
                    new StockListing { TickerSymbol = "AAPL", Price = 464.90 },
                    new StockListing { TickerSymbol = "IBM", Price = 192.50  },
                    new StockListing { TickerSymbol = "GOOG", Price = 890.20  },
                    new StockListing { TickerSymbol = "MSFT", Price = 33.03  }
            };
        //---------------------------------


        public IEnumerable<StockListing> GetStocks()
        {
            return listings.OrderBy(s => s.TickerSymbol);
        }

        public StockListing GetStock(string ticker)
        {
            // LINQ query, find matching ticker (case-insensitive) or default value (null) if none matching
            var listing = listings.SingleOrDefault(l => l.TickerSymbol.ToUpper() == ticker.ToUpper());
            return listing;
        }
    }
}
