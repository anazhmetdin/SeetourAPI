using SeetourAPI.Data.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.Data.Models
{
    public class TourAnswer
    {
        public int Id { get; set; }
        public TourQuestion? TourQuestion { get; set; }
        public int TourQuestionId { get; set; }
        [StringLength(512, MinimumLength = 32)]
        public string Answer { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
