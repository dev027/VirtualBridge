// <copyright file="IRegularCompetition.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using VirtualBridge.Domain.DomainObjects.Competitions;

namespace VirtualBridge.Domain.DomainObjects.RegularCompetitions
{
    /// <summary>
    /// Regular Competition.
    /// </summary>
    /// <seealso cref="ICompetition" />
    public interface IRegularCompetition : ICompetition
    {
        /// <summary>
        /// Gets the Day of Week.
        /// </summary>
        DayOfWeek DayOfWeek { get; }

        /// <summary>
        /// Gets the Time of day.
        /// </summary>
        TimeSpan TimeOfDay { get; }
    }
}