// <copyright file="Competition.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Domain.ValidationAttributes;

namespace VirtualBridge.Domain.DomainObjects.Competitions
{
    /// <summary>
    /// Competition.
    /// </summary>
    /// <seealso cref="ICompetition" />
    public abstract class Competition : BaseDomainModel, ICompetition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Competition"/> class.
        /// </summary>
        /// <param name="id">Competition Id.</param>
        /// <param name="name">Competition Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="organisation">Organisation.</param>
        protected Competition(
            Guid id,
            string name,
            string description,
            IOrganisation organisation)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Organisation = organisation;
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

        /// <inheritdoc />
        [Required]
        public IOrganisation Organisation { get; }
    }
}