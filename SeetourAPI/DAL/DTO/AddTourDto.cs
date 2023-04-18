using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.DAL.DTO
{
    public class AddTourDto
    {
        public int Id { get; set; }
       
        public string Title { get; set; } = string.Empty;
      
        public string Description { get; set; } = string.Empty;
    
        public DateTime DateFrom { get; set; }
     
        public DateTime DateTo { get; set; }
       
        public decimal Price { get; set; }
       
        public string LocationFromUrl { get; set; } = string.Empty;
     
        public string LocationFrom { get; set; } = string.Empty;

   
        public string LocationToUrl { get; set; } = string.Empty;
     
        public string LocationTo { get; set; } = string.Empty;
        public TourCategory Category { get; set; } = TourCategory.OTHER;
        public bool HasTransportation { get; set; }
       
        public DateTime LastDateToCancel { get; set; }
     
        public int Capacity { get; set; }
        public TourPostingStatus TourPostingStatus { get; set; }
        public bool IsCompleted { get => DateFrom < DateTime.Now; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
        public string? TourGuideId { get; set; }
    }
}
