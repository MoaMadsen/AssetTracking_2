namespace AssetTracking_2
{
    public class AssetItem
    {
        private int _endofdate;

        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Currency Currency { get; set; }
        public string CurrencyCountry { get; set; }
        public int PurchaseDate { get; set; }
        public int EndOfLife { get; set; }
        /* {
             get => _endofdate;
             set
             {
                 _endofdate = PurchaseDate + 30000;
             }
         }*/
        public double Price { get; set; }

    }
    class Computer : AssetItem
    {
        public Computer(int id, string brand, string model, string office, int purchase, double price)
        {
            Id = id;
            Type = "computer";
            Brand = brand;
            Model = model;
            CurrencyCountry = office;
            PurchaseDate = purchase;
            EndOfLife = PurchaseDate + 30000;
            Price = price;
        }
    }
    class Mobile : AssetItem
    {
        public Mobile(int id,string brand, string model, string office, int purchase, double price)
        {
            Id=id;
            Type = "mobile";
            Brand = brand;
            Model = model;
            CurrencyCountry = office;
            PurchaseDate = purchase;
            EndOfLife = PurchaseDate + 30000;
            Price = price;
        }
    }
}