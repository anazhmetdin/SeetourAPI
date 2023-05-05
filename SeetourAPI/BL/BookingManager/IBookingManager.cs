namespace SeetourAPI.BL.BookingManager
{
	public interface IBookingManager
	{
		bool CancelBooking(string userId, int bookingId);
	}
}
