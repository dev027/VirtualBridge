// <copyright file="DateTimeExtensions.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.Extensions.TimeSpans;

namespace VirtualBridge.Domain.Extensions.DateTimes
{
    /// <summary>
    /// <see cref="DateTime"/> extension methods.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a <see cref="DateTime"/> to <see cref="ETimePeriod"/>.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>Time Period.</returns>
        public static ETimePeriod ToTimePeriod(this DateTime dateTime)
        {
            TimeSpan timeOfDay = dateTime - dateTime.Date;
            return timeOfDay.ToTimePeriod();
        }
    }
}