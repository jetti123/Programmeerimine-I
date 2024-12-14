using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Asset
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("AssetClass")]
        public int AssetClassId { get; set; }
        public AssetClass AssetClass { get; set; }
    }
}
