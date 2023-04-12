using SeetourAPI.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.Data.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 16)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Price { get; set; }
        public string LocationFrom { get; set; } = string.Empty;
        public string LocationTo { get; set; } = string.Empty;
        public TourCategory Category { get; set; } = TourCategory.OTHER;
        public bool HasTransportation { get; set; }
        public DateTime LastDateToCancel { get; set; }
        public IEnumerable<string> Photos { get; set; } = Enumerable.Empty<string>();
    }
}
