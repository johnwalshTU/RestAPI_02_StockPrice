using RestAPI_02_StockPrice.Models;

namespace RestAPI_02_StockPrice.Database
{
    public interface IRepository
    {
        IEnumerable<StockListing> GetStocks();
        StockListing GetStock(String ticker);
    }
}
