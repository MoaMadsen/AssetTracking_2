// See https://aka.ms/new-console-template for more information

using AssetTracking_2;
using Microsoft.EntityFrameworkCore;

MyDbContext Context = new MyDbContext();
var dataset = 0;

// first sort data and then call Write output method
Console.WriteLine("\t\t\t*** Asset Tracking ***");

// sort assets by Type and then by purchase date
var sortedTypeDate = Context.assetitems.Include(x => x.Currency).OrderBy(asset => asset.Type).ThenBy(asset => asset.PurchaseDate);
Console.WriteLine("\t\t Data sorted by Type and then Purchase date");
dataset = 1;
Write_output(sortedTypeDate,dataset);

// sort assets by country and then purchase date
var sortedOfficePdate = Context.assetitems.Include(x => x.Currency).OrderBy(asset => asset.CurrencyCountry).ThenBy(asset => asset.PurchaseDate);
Console.WriteLine("\t\t Data sorted by Country and then Purchase date");
dataset = 2;
Write_output(sortedOfficePdate,dataset);



// write output method
void Write_output(IOrderedQueryable<AssetItem> assets,int dataset)
{
    Console.ResetColor();
    // string mainCurrency = "USD";
    if (dataset == 1)
    {
        Console.WriteLine("Type".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(10) + "Office".PadRight(10) + "Purchase Date " + "Price in USD " + "Currency " + "Local price today");
        Console.WriteLine("----".PadRight(10) + "-----".PadRight(10) + "-----".PadRight(10) + "------".PadRight(10) + "------------- " + "------------ " + "-------- " + "-----------------");

    }
    else
    {
        Console.WriteLine("Office".PadRight(10) + "Type".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(10) + "Purchase Date " +"Price in USD " + "Currency " + "Local price today");
        Console.WriteLine("------".PadRight(10) + "----".PadRight(10) + "-----".PadRight(10) + "-----".PadRight(10) + "------------- " + "------------ " + "-------- " + "-----------------");
    }
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
        if (dataset == 1)
        {
            Console.WriteLine(a.Type.PadRight(10) + a.Brand.PadRight(10) + a.Model.PadRight(10) + a.CurrencyCountry.PadRight(10) + Pdate.ToString("yyyy-MM-dd") + a.Price.ToString("N2").PadLeft(12) + a.Currency.Shorten.PadLeft(10) + NewPrice.PadLeft(12));
        }
        else
        {
            Console.WriteLine(a.CurrencyCountry.PadRight(10) + a.Type.PadRight(10) + a.Brand.PadRight(10) + a.Model.PadRight(10) + Pdate.ToString("yyyy-MM-dd") + a.Price.ToString("N2").PadLeft(12) + a.Currency.Shorten.PadLeft(10) + NewPrice.PadLeft(12));
        }
    }
    Console.ResetColor();
    Console.WriteLine();
}
