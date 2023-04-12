using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Validation;
using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.Data.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 16)]
        public string Title { get; set; } = string.Empty;
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;
        [FutureDateRange(1)] // 1 day in the future
        public DateTime DateFrom { get; set; }
        [FutureDateRange(0, "DateFrom")] // at least 0 days after DateFrom
        public DateTime DateTo { get; set; }
        [Range(0, (double)decimal.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Url)]
        [StringLength(512)]
        public string LocationFrom { get; set; } = string.Empty;
        [DataType(DataType.Url)]
        [StringLength(512)]
        public string LocationTo { get; set; } = string.Empty;
        public TourCategory Category { get; set; } = TourCategory.OTHER;
        public bool HasTransportation { get; set; }
        [FutureDateRange(0, dateBefore: "DateFrom")] // at most 0 days before after datefrom
        public DateTime LastDateToCancel { get; set; }
        public IEnumerable<string> Photos { get; set; } = Enumerable.Empty<string>();
    }
}
