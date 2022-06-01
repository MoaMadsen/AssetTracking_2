// See https://aka.ms/new-console-template for more information

using AssetTracking_2;
using Microsoft.EntityFrameworkCore;

MyDbContext Context = new MyDbContext();

// sort assets by Type and then by purchase date

var sortedTypeDate = Context.assetitems.Include(x => x.Currency).OrderBy(asset => asset.Type).ThenBy(asset => asset.PurchaseDate);
// call Write output method using 
Write_output(sortedTypeDate);


// Write_output1(assets, currencyCode);
var sortedOfficePdate = Context.assetitems.Include(x => x.Currency).OrderBy(asset => asset.CurrencyCountry).ThenBy(asset => asset.PurchaseDate);
Write_output(sortedOfficePdate);


// write output
void Write_output(IOrderedQueryable<AssetItem> assets)
// private static void Write_output1(List<AssetItem> assets, List<Currency> currencies)
{
    Console.ResetColor();
    // string mainCurrency = "USD";
    Console.WriteLine("{0," + 30 + "}", "*** Asset Tracking ***");
    Console.WriteLine("Type".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(10) + "Office".PadRight(10) + "Purchase Date " + "Price in USD " + "Currency " + "Local price today");
    Console.WriteLine("----".PadRight(10) + "-----".PadRight(10) + "-----".PadRight(10) + "------".PadRight(10) + "------------- " + "------------ " + "-------- " + "-----------------");
    foreach (AssetItem a in assets)
    {
 
        DateTime Pdate = new(a.PurchaseDate / 10000, (a.PurchaseDate / 100) % 100, a.PurchaseDate % 100);
        DateTime Edate = new(a.EndOfLife / 10000, (a.EndOfLife / 100) % 100, a.EndOfLife % 100);
        TimeSpan diff = Edate - DateTime.Today;
        string NewPrice = (a.Price * a.Currency.Rate).ToString("N2");

        // checking if if purchase date is less than 3 months away from 3 years.
        if (diff.Days < 90)
            Console.ForegroundColor = ConsoleColor.DarkRed;
        else if (diff.Days < 180)
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        else
            Console.ResetColor();

        Console.WriteLine(a.Type.PadRight(10) + a.Brand.PadRight(10) + a.Model.PadRight(10) + a.CurrencyCountry.PadRight(10) + Pdate.ToString("yyyy-MM-dd") + a.Price.ToString("N2").PadLeft(12) + a.Currency.Shorten.PadLeft(10) + NewPrice.PadLeft(12));
    }
    Console.ResetColor();
    Console.WriteLine();
}
