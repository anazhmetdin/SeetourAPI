using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.Data.Models
{
    public class TourAnswer
    {
        public int Id { get; set; }
        public TourQuestion? TourQuestion { get; set; }
        public int TourQuestionId { get; set; }
        public string Answer { get; set; } = string.Empty;
    }
}
