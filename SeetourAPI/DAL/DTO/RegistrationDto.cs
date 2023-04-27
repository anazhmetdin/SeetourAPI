namespace SeetourAPI.DAL.DTO
{
    public record CustomerRegistrationDto(string UserName, string Password,string profilepic, string SSN, string FullName,string PhoneNumber,string Email);

    public record TourGuideRegistrationDto(
        string UserName, 
        string Password,
        string profilepic,
        string SSN,
        string FullName,
        string RecipientBankNameAndAddress,
        string RecipientAccountNumberOrIBAN,
        string RecipientBankSwiftCode,
        string RecipientNameAndAddress,
        string TaxRegistrationNumber,
        string IDCardPhoto,
        string PhoneNumber,
        string Email
        );
    
        
    
}
