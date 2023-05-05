using SeetourAPI.Data.Models.Photos;
using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.DTO
{
    public class photoDto
    {
        public int Id { get; set; }
        //public string? URL { get; set; }
        public int PhotoId { get; set; }
        public int TourId { get; set; }
      
        
    }
}
