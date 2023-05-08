using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SeetourAPI.Data.Models.Photos;

namespace SeetourAPI.DAL.DTO
{
    public class AddTourDto
    {
        public int id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime dateTo { get; set; }
        public string LocationFromUrl { get; set; } = string.Empty;
        public string LocationToUrl { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime LastDateToCancel { get; set; }
        public string LocationFrom { get; set; } = string.Empty;
        public string LocationTo { get; set; } = string.Empty;
        public bool HasTransportation { get; set; }
        public virtual ICollection<photoDto> Photos { get; set; } = new HashSet<photoDto>();

        public TourCategory category { get; set; }
    }
}
