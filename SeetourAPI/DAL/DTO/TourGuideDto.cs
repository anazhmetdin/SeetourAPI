using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.DAL.DTO
{
	public record TourGuideDto(
		string Id,
		string Username,
		string Name,
		string ProfilePic,
		string RecipientBankNameAndAddress,
		string RecipientAccountNumberOrIBAN,
		string RecipientBankSwiftCode,
		string RecipientNameAndAddress,
		string TaxRegistrationNumber,
		string IDCardPhoto,
		string SSN,
		string Email,
		string Phone
	);
}
