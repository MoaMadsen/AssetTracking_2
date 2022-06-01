using System.ComponentModel.DataAnnotations;

namespace AssetTracking_2
{
    public class Currency
    { 
        [Key]
        public string Country { get; set; }
        public string Shorten { get; set; }
        public double Rate { get; set; }

        
    }
}