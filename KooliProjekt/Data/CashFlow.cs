using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class CashFlow
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [StringLength(255)]
        public string Description { get; set; } // Optional description
    }
}
