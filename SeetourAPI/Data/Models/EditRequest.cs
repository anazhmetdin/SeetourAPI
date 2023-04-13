using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.Data.Models
{
    public class EditRequest
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public Tour? Tour { get; set; }
        [StringLength(256, MinimumLength = 64)]
        public string AdminComments { get; set; } = string.Empty;
    }
}
