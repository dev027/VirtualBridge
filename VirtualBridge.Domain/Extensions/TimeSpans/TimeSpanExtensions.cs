﻿// <copyright file="TimeSpanExtensions.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using VirtualBridge.Domain.Constants;

namespace VirtualBridge.Domain.Extensions.TimeSpans
{
    /// <summary>
    /// <see cref="TimeSpan"/> extension methods.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Converts Time of Day to Time Period.
        /// </summary>
        /// <param name="timeOfDay">Time of Day.</param>
        /// <returns>Time Period.</returns>
        public static ETimePeriod ToTimePeriod(this TimeSpan timeOfDay)
        {
            TimeSpan timeOfDayWithoutDays = new TimeSpan(
                timeOfDay.Hours,
                timeOfDay.Minutes,
                timeOfDay.Seconds);

            if (IsMorning(timeOfDayWithoutDays))
            {
                return ETimePeriod.Morning;
            }

            return IsEvening(timeOfDayWithoutDays)
                ? ETimePeriod.Evening
                : ETimePeriod.Afternoon;
        }

        private static bool IsMorning(TimeSpan timeOfDayWithoutDays)
        {
            TimeSpan time1200 = new TimeSpan(12, 0, 0);
            return timeOfDayWithoutDays < time1200;
        }

        private static bool IsEvening(TimeSpan timeOfDayWithoutDays)
        {
            TimeSpan time1800 = new TimeSpan(18, 0, 0);

            return timeOfDayWithoutDays >= time1800;
        }
    }
}