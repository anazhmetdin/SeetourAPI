using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.DTO
{
    public class paymentInfoDto
    {
        public decimal Amount { get; set; }
        public string ?Currency { get; set; }=string.Empty;
        public string ?CardNumber { get; set; }= string.Empty;
        public string? ExpDate { get; set; } = string.Empty;
        public string? CardHolderName { get; set; } = string.Empty;
        public DateTime? DateTime { get; set; }
        public int bookedTourId { get; set; }
       
    }
}
