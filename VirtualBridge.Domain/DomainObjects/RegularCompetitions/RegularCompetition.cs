// <copyright file="RegularCompetition.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using VirtualBridge.Domain.DomainObjects.Competitions;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Domain.ValidationAttributes;

namespace VirtualBridge.Domain.DomainObjects.RegularCompetitions
{
    /// <summary>
    /// Regular Competition.
    /// </summary>
    /// <seealso cref="Competition" />
    /// <seealso cref="IRegularCompetition" />
    public class RegularCompetition : Competition, IRegularCompetition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegularCompetition"/> class.
        /// </summary>
        /// <param name="id">Competition Id.</param>
        /// <param name="name">Competition Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="organisation">Organisation.</param>
        /// <param name="dayOfWeek">Day of the Week.</param>
        /// <param name="timeOfDay">Time of the Day.</param>
        public RegularCompetition(
            Guid id,
            string name,
            string description,
            IOrganisation organisation,
            DayOfWeek dayOfWeek,
            TimeSpan timeOfDay)
            : base(
                id: id,
                name: name,
                description: description,
                organisation: organisation)
        {
            this.DayOfWeek = dayOfWeek;
            this.TimeOfDay = timeOfDay;

            Validate(this);
        }

        /// <inheritdoc/>
        public DayOfWeek DayOfWeek { get; }

        /// <inheritdoc/>
        [Required]
        [ValidTimeOfDay]
        public TimeSpan TimeOfDay { get; }
    }
}