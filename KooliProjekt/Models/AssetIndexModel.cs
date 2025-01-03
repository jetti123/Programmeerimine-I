using KooliProjekt.Data;
using KooliProjekt.Search;
using System.Collections.Generic;

namespace KooliProjekt.Models
{
    public class AssetIndexModel
    {
        public List<Asset> Assets { get; set; } = new List<Asset>();
        public AssetSearch Search { get; set; } = new AssetSearch();
        public List<AssetClass> AssetClasses { get; set; } = new List<AssetClass>();
    }
}

