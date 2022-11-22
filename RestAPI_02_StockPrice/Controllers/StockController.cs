using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI_02_StockPrice.Database;
using RestAPI_02_StockPrice.Models;

namespace RestAPI_02_StockPrice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        //------------------------------------------
        // --- Use Repository ----
        //NB : add the following line to Program.cs (to inject in MockDB)
        //    builder.Services.AddScoped<IRepository, MockDB>();
        private readonly IRepository _db;

        public StockController(IRepository db)
        {
            _db = db; // new MockDB();
        }
        //------------------------------------------------


        // GET https://localhost:7117/api/Stock   (api/stock is the URL that will get us to this controller .. 
        [HttpGet]
        public ActionResult<IEnumerable<StockListing>> GetAllListings()
        {
            //return Ok(_db.GetStocks().ToList());      // 200 OK, listings serialized in response body
            return _db.GetStocks().ToList();            //default is 200 OK
        }



        // GET https://localhost:7117/api/Stock/AAPL
        //   or
        // GET https://localhost:7117/api/Stock?ticker=AAPL       
        [HttpGet("{ticker}")]
        public ActionResult<double> GetStockPrice(String ticker)
        {            
            StockListing listing = _db.GetStock(ticker);
            if (listing == null)
            {
                return NotFound();
            }

            //return Ok(listing.Price);
            return listing.Price;          //default is 200 OK
        }


    }
}
