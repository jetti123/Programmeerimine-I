using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class MonthlyData
    {
        public int Id { get; set; }

        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public decimal? Quantity { get; set; } // Quantity is optional

        [Required]
        public decimal Value { get; set; } // Value is required
    }
}
