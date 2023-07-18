using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace OnDijon.Models.Attributes
{
    public class MaxDateAttribute : ValidationAttribute
    {
        private readonly DateTimeOffset _maxDate;

        public MaxDateAttribute()
        {
            _maxDate = DateTimeOffset.Now;
        }

        public override bool IsValid(object value)
        {
            DateTimeOffset date = DateTimeOffset.ParseExact((string)value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return date <= _maxDate;
        }
    }
}
