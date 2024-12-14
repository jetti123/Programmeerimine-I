using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class AssetClass
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
