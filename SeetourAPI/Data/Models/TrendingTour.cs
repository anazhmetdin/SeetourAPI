using System.ComponentModel.DataAnnotations.Schema;

namespace SeetourAPI.Data.Models
{
	public class TrendingTour
	{
		public int Id { get; set; }
		public int TourId { get; set; }
		public virtual Tour? Tour { get; set; }
	}
}
