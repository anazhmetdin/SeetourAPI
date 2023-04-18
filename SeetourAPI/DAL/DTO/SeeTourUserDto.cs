namespace SeetourAPI.DAL.DTO
{
    public record SeeTourUserDto(
        string UserName,
        string Password,
        string profilepic,
        string SSN,
        string FullName,
        string SecurityLevel,
        string RecipientBankNameAndAddress,
        string RecipientAccountNumberOrIBAN,
        string RecipientBankSwiftCode,
        string RecipientNameAndAddress,
        string TaxRegistrationNumber,
        string IDCardPhoto,
        string PhoneNumber,
        string Email
       
        );
    public record SeeTourUserDtoGetId(
        string UserName,
        string profilepic,
        string SSN,
        string FullName,
        string SecurityLevel,
        string RecipientBankNameAndAddress,
        string RecipientAccountNumberOrIBAN,
        string RecipientBankSwiftCode,
        string RecipientNameAndAddress,
        string TaxRegistrationNumber,
        string IDCardPhoto,
        string PhoneNumber,
        string Email)
    {
        public SeeTourUserDtoGetId() : this("", "", "", "", "", "", "", "", "", "", "", "", "")
        {
        }
    }
}
