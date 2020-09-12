// <copyright file="Competition.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Domain.ValidationAttributes;

namespace VirtualBridge.Domain.DomainObjects.Competitions
{
    /// <summary>
    /// Competition.
    /// </summary>
    /// <seealso cref="ICompetition" />
    public class Competition : BaseDomainModel, ICompetition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Competition"/> class.
        /// </summary>
        /// <param name="id">Competition Id.</param>
        /// <param name="name">Competition Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="dayOfWeek">Day of the Week.</param>
        /// <param name="timeOfDay">Time of the Day.</param>
        /// <param name="timePeriod">Time Period.</param>
        /// <param name="organisation">Organisation.</param>
        public Competition(
            Guid id,
            string name,
            string description,
            DayOfWeek dayOfWeek,
            TimeSpan timeOfDay,
            ETimePeriod timePeriod,
            IOrganisation organisation)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.DayOfWeek = dayOfWeek;
            this.TimeOfDay = timeOfDay;
            this.TimePeriod = timePeriod;
            this.Organisation = organisation;

            Validate(this);
        }

        /// <inheritdoc/>
        [ValidId]
        public Guid Id { get; }

        /// <inheritdoc/>
        [Required]
        [StringLength(
            maximumLength: Metadata.Name.MaxLength,
            MinimumLength = Metadata.Name.MinLength)]
        public string Name { get; }

        /// <inheritdoc/>
        [Required]
        [StringLength(
            maximumLength: Metadata.Description.MaxLength,
            MinimumLength = Metadata.Description.MinLength)]
        public string Description { get; }

        /// <inheritdoc/>
        public DayOfWeek DayOfWeek { get; }

        /// <inheritdoc/>
        [Required]
        [ValidTimeOfDay]
        public TimeSpan TimeOfDay { get; }

        /// <inheritdoc/>
        [ValidTimePeriod(nameof(TimeOfDay))]
        public ETimePeriod TimePeriod { get; }

        /// <inheritdoc />
        [Required]
        public IOrganisation Organisation { get; }
    }
}