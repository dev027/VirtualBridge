// <copyright file="OrganisationDto.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualBridge.Data.DbContexts;
using VirtualBridge.Domain.DomainObjects.Organisations;

namespace VirtualBridge.Data.Dtos
{
    /// <summary>
    /// Organisation DTO.
    /// </summary>
    [Table(nameof(DataContext.Organisations))]
    public class OrganisationDto : BaseDto
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganisationDto"/> class.
        /// </summary>
        public OrganisationDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganisationDto"/> class.
        /// </summary>
        /// <param name="id">Organisation Id.</param>
        /// <param name="shortName">Short Name.</param>
        /// <param name="mediumName">Medium Name.</param>
        /// <param name="longName">Long Name.</param>
        /// <param name="code">Code.</param>
        public OrganisationDto(
            Guid id,
            string shortName,
            string mediumName,
            string longName,
            string code)
        {
            this.Id = id;
            this.ShortName = shortName;
            this.MediumName = mediumName;
            this.LongName = longName;
            this.Code = code;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the Organisation Id.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the Short Name.
        /// </summary>
        [Required]
        [MaxLength(Domain.DomainObjects.Organisations.Metadata.ShortName.MaxLength)]
        public string ShortName { get; private set; } = null!;

        /// <summary>
        /// Gets the Medium Name.
        /// </summary>
        [Required]
        [MaxLength(Domain.DomainObjects.Organisations.Metadata.MediumName.MaxLength)]
        public string MediumName { get; private set; } = null!;

        /// <summary>
        /// Gets the Long Name.
        /// </summary>
        [Required]
        [MaxLength(Domain.DomainObjects.Organisations.Metadata.LongName.MaxLength)]
        public string LongName { get; private set; } = null!;

        /// <summary>
        /// Gets the Code.
        /// </summary>
        [Required]
        [MaxLength(Domain.DomainObjects.Organisations.Metadata.Code.MaxLength)]
        public string Code { get; private set; } = null!;

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Converts domain object to DTO.
        /// </summary>
        /// <param name="organisation">Organisation.</param>
        /// <returns>Organisation DTO.</returns>
        public static OrganisationDto ToDto(IOrganisation organisation)
        {
            if (organisation == null)
            {
                throw new ArgumentNullException(nameof(organisation));
            }

            return new OrganisationDto(
                id: organisation.Id,
                shortName: organisation.ShortName,
                mediumName: organisation.MediumName,
                longName: organisation.LongName,
                code: organisation.Code);
        }

        /// <summary>
        /// Converts instance to domain object.
        /// </summary>
        /// <returns>Organisation.</returns>
        public IOrganisation ToDomain()
        {
            return new Organisation(
                id: this.Id,
                shortName: this.ShortName,
                mediumName: this.MediumName,
                longName: this.LongName,
                code: this.Code);
        }

        #endregion
    }
}