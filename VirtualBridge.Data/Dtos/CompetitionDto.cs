// <copyright file="CompetitionDto.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtualBridge.Data.DbContexts;
using VirtualBridge.Data.Resources;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.Competitions;

namespace VirtualBridge.Data.Dtos
{
    /// <summary>
    /// Competition DTO.
    /// </summary>
    [Table(nameof(DataContext.Competitions))]
    public class CompetitionDto : BaseDto
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitionDto"/> class.
        /// </summary>
        public CompetitionDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitionDto"/> class.
        /// </summary>
        /// <param name="id">Competition Id.</param>
        /// <param name="name">Competition Name.</param>
        /// <param name="description">Competition Description.</param>
        /// <param name="dayOfWeek">Day of Week.</param>
        /// <param name="timeOfDay">Time of Day.</param>
        /// <param name="timePeriod">Time Period.</param>
        /// <param name="organisationId">Organisation Id.</param>
        public CompetitionDto(
            Guid id,
            string name,
            string description,
            DayOfWeek dayOfWeek,
            TimeSpan timeOfDay,
            ETimePeriod timePeriod,
            Guid organisationId)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.DayOfWeek = dayOfWeek;
            this.TimeOfDay = timeOfDay;
            this.TimePeriod = timePeriod;
            this.OrganisationId = organisationId;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the Competition Id.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the  Name.
        /// </summary>
        [Required]
        [MaxLength(Domain.DomainObjects.Competitions.Metadata.Name.MaxLength)]
        public string Name { get; private set; } = null!;

        /// <summary>
        /// Gets the  Description.
        /// </summary>
        [Required]
        [MaxLength(Domain.DomainObjects.Competitions.Metadata.Description.MaxLength)]
        public string Description { get; private set; } = null!;

        /// <summary>
        /// Gets the Day of Week.
        /// </summary>
        [Required]
        [MaxLength(10)]
        public DayOfWeek DayOfWeek { get; private set; }

        /// <summary>
        /// Gets the Time of Day.
        /// </summary>
        [Required]
        public TimeSpan TimeOfDay { get; private set; }

        /// <summary>
        /// Gets the Time Period.
        /// </summary>
        [Required]
        [MaxLength(10)]
        public ETimePeriod TimePeriod { get; private set; }

        /// <summary>
        /// Gets the Organisation Id.
        /// </summary>
        [Required]
        public Guid OrganisationId { get; private set; }

        #endregion Properties

        #region Parent Properties

        /// <summary>
        /// Gets the Organisation.
        /// </summary>
        [ForeignKey(nameof(OrganisationId))]
        public OrganisationDto Organisation { get; private set; } = null!;

        #endregion Parent Properties

        #region Public Methods

        /// <summary>
        /// Called when [model building].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        /// <param name="converterDayOfWeek">Day of week converter.</param>
        /// <param name="converterETimePeriod">Time period converter.</param>
        public static void OnModelBuilding(
            ModelBuilder modelBuilder,
            EnumToStringConverter<DayOfWeek> converterDayOfWeek,
            EnumToStringConverter<ETimePeriod> converterETimePeriod)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<CompetitionDto>()
                .Property(p => p.DayOfWeek)
                .HasConversion(converterDayOfWeek);

            modelBuilder.Entity<CompetitionDto>()
                .Property(p => p.TimePeriod)
                .HasConversion(converterETimePeriod);
        }

        /// <summary>
        /// Converts domain object to DTO.
        /// </summary>
        /// <param name="competition">Competition.</param>
        /// <returns>Competition DTO.</returns>
        public static CompetitionDto ToDto(ICompetition competition)
        {
            if (competition == null)
            {
                throw new ArgumentNullException(nameof(competition));
            }

            return new CompetitionDto(
                id: competition.Id,
                name: competition.Name,
                description: competition.Description,
                dayOfWeek: competition.DayOfWeek,
                timeOfDay: competition.TimeOfDay,
                timePeriod: competition.TimePeriod,
                organisationId: competition.Organisation.Id);
        }

        /// <summary>
        /// Converts instance to domain object.
        /// </summary>
        /// <returns>Competition.</returns>
        public ICompetition ToDomain()
        {
            if (this.Organisation == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        ExceptionResource.CannotConvertTo___If___IsNull,
                        nameof(ICompetition),
                        nameof(this.Organisation)));
            }

            return new Competition(
                id: this.Id,
                name: this.Name,
                description: this.Description,
                dayOfWeek: this.DayOfWeek,
                timeOfDay: this.TimeOfDay,
                timePeriod: this.TimePeriod,
                organisation: this.Organisation.ToDomain());
        }

        #endregion Public Methods
    }
}