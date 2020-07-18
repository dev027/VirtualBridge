// <copyright file="Organisation.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using VirtualBridge.Domain.ValidationAttributes;

namespace VirtualBridge.Domain.DomainObjects.Organisations
{
    /// <summary>
    /// Organisation.
    /// </summary>
    public class Organisation : BaseDomainModel, IOrganisation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Organisation"/> class.
        /// </summary>
        /// <param name="id">Organisation Id.</param>
        /// <param name="shortName">Short Name.</param>
        /// <param name="mediumName">Medium Name.</param>
        /// <param name="longName">Long Name.</param>
        /// <param name="code">Code.</param>
        public Organisation(
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

            Validate(this);
        }

        /// <inheritdoc />
        [ValidId]
        public Guid Id { get; }

        /// <inheritdoc/>
        [Required]
        [StringLength(
            maximumLength: Metadata.ShortName.MaxLength,
            MinimumLength = Metadata.ShortName.MinLength)]
        public string ShortName { get; }

        /// <inheritdoc/>
        [Required]
        [StringLength(
            maximumLength: Metadata.MediumName.MaxLength,
            MinimumLength = Metadata.MediumName.MinLength)]
        public string MediumName { get; }

        /// <inheritdoc/>
        [Required]
        [StringLength(
            maximumLength: Metadata.LongName.MaxLength,
            MinimumLength = Metadata.LongName.MinLength)]
        public string LongName { get; }

        /// <inheritdoc/>
        [Required]
        [StringLength(
            maximumLength: Metadata.Code.MaxLength,
            MinimumLength = Metadata.Code.MinLength)]
        public string Code { get; }
    }
}