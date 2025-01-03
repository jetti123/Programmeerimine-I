namespace KooliProjekt.Search
{
    public class AssetSearch
    {
        public string? SearchTerm { get; set; } // Otsingusõna
        public int? AssetClassId { get; set; } // Filtreerimine varaklassi järgi
        public bool? IsDone { get; set; } // Staatus
    }
}

