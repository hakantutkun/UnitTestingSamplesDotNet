using System;
using System.ComponentModel.DataAnnotations;

namespace Bongo.Models.ModelValidations
{
    /// <summary>
    /// A Custom Validation attribute that controls if the selected date is future date or not.
    /// </summary>
    public class DateInFutureAttribute : ValidationAttribute
    {
        /// <summary>
        /// DateTime Now Provider
        /// </summary>
        private readonly Func<DateTime> _dateTimeNowProvider;

        /// <summary>
        /// Constructor
        /// </summary>
        public DateInFutureAttribute() : this(() => DateTime.Now)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dateTimeNowProvider">Provider</param>
        public DateInFutureAttribute(Func<DateTime> dateTimeNowProvider)
        {
            _dateTimeNowProvider = dateTimeNowProvider;
            ErrorMessage = "Date must be in the future";
        }

        /// <summary>
        /// Validation checker
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            bool isValid = false;

            if (value is DateTime dateTime)
            {
                isValid = dateTime > _dateTimeNowProvider();
            }

            return isValid;
        }
    }
}
