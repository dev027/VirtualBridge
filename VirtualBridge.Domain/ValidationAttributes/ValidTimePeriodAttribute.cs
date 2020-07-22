// <copyright file="ValidTimePeriodAttribute.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.Extensions.TimeSpans;

namespace VirtualBridge.Domain.ValidationAttributes
{
    /// <summary>
    /// Validate Time Period.
    /// </summary>
    /// <seealso cref="ValidationAttribute" />
    public sealed class ValidTimePeriodAttribute : ValidationAttribute
    {
        private readonly string timeOfDayPropertyName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidTimePeriodAttribute"/> class.
        /// </summary>
        /// <param name="timeOfDayPropertyName">Name of the time of day property.</param>
        public ValidTimePeriodAttribute(string timeOfDayPropertyName)
        {
            this.timeOfDayPropertyName = timeOfDayPropertyName;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="System.ComponentModel.DataAnnotations.ValidationResult"></see> class.
        /// </returns>
        /// <exception cref="ArgumentException">Time of Day property not found.</exception>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }

            PropertyInfo timeOfDayProperty = validationContext.ObjectType.GetProperty(this.timeOfDayPropertyName);

            if (timeOfDayProperty == null)
            {
                throw new ArgumentException("Time of Day property not found");
            }

            object timeOfDayObj = timeOfDayProperty.GetValue(validationContext.ObjectInstance);

            ValidTimeOfDayAttribute validTimeOfDayAttribute = new ValidTimeOfDayAttribute();
            if (timeOfDayObj == null || !validTimeOfDayAttribute.IsValid(timeOfDayObj))
            {
                return ValidationResult.Success;
            }

            if (!(value is ETimePeriod))
            {
                return new ValidationResult($"Attribute can only be used on a {nameof(ETimePeriod)}");
            }

            ETimePeriod inputValue = (ETimePeriod)value;

            ETimePeriod expectedTimePeriod = ((TimeSpan)timeOfDayObj).ToTimePeriod();

            if (inputValue == expectedTimePeriod)
            {
                return ValidationResult.Success;
            }

            DisplayAttribute timeOfDayDisplayAttr = timeOfDayProperty.GetCustomAttribute<DisplayAttribute>();
            string timeOfDayDisplayName = timeOfDayDisplayAttr?.Name ?? this.timeOfDayPropertyName;

            return new ValidationResult(
                $"{validationContext.DisplayName} is inconsistent with {timeOfDayDisplayName}.");
        }
    }
}