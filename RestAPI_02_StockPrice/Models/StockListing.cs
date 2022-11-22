using System.ComponentModel.DataAnnotations;


/*
 
I've added in Modle validation in StockListing below
For Webapi modle validation erros automatically trigger a htpp 400 (Bad Request) responces 
I dont need to do a   ModelState.IsValid check like i do for Web MVC APP
(run the app and add in an invalid price and you will see the htpp 400 response)
*/

namespace RestAPI_02_StockPrice.Models

{
    // a listing for a stock on the stock market
    public class StockListing
    {
        // ticker symbol e.g. AAPL, GOOG, IBM, MSFT
        [Required]
        public string TickerSymbol { get; set; } = "";

        // price last trade in $
        [Range(0, 1000)]
        public double Price { get; set; }
       

    }
}
