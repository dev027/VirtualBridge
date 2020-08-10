// <copyright file="ValidTimeOfDayAttribute.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace VirtualBridge.Domain.ValidationAttributes
{
    /// <summary>
    /// Validate HH:MM.
    /// </summary>
    /// <seealso cref="ValidationAttribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ValidTimeOfDayAttribute : ValidationAttribute
    {
        /// <inheritdoc />
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }

            if (!(value is TimeSpan))
            {
                return false;
            }

            TimeSpan inputValue = (TimeSpan)value;

            bool isValid = inputValue.Days == 0 &&
                           inputValue.Seconds == 0 &&
                           inputValue.Milliseconds == 0 &&
                           inputValue.Ticks >= 0;
            return isValid;
        }

        /// <inheritdoc/>
        public override string FormatErrorMessage(string name)
        {
            return $"'{name}' must be a valid time of day (hours and minutes only)";
        }
    }
}