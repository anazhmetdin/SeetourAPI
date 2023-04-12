using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.Data.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class FutureDateRangeAttribute : ValidationAttribute
    {
        private readonly int _days;
        private readonly string? _dateAfter;
        private readonly string? _dateBefore;

        public FutureDateRangeAttribute(int days, string? dateAfter = null, string? dateBefore = null)
        {
            _days = days;
            _dateAfter = dateAfter;
            _dateBefore = dateBefore;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            var futureDate = value as DateTime?;
            var memberNames = new List<string>() { context.MemberName! };

            if (futureDate == null)
                return new ValidationResult("Invalid value", memberNames);

            DateTime dateAfter = context.Items[_dateAfter??""] as DateTime? ?? DateTime.Now;
            DateTime dateBefore = context.Items[_dateBefore??""] as DateTime? ?? DateTime.MaxValue;

            if (futureDate != null)
            {
                if (futureDate.Value <= dateAfter.AddDays(_days) && futureDate.Value <= dateBefore)
                {
                    return new ValidationResult($"This date must at least {_days} days after {dateAfter}", memberNames);
                }
            }

            return ValidationResult.Success;
        }
    }
}
