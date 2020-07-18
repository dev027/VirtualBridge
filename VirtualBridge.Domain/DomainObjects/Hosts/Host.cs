// <copyright file="Host.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using VirtualBridge.Domain.ValidationAttributes;

namespace VirtualBridge.Domain.DomainObjects.Hosts
{
    /// <summary>
    /// Virtual Bridge Club Host.
    /// </summary>
    /// <seealso cref="IHost" />
    public class Host : BaseDomainModel, IHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Host"/> class.
        /// </summary>
        /// <param name="id">Host Id.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="surname">Surname.</param>
        public Host(
            Guid id,
            string firstName,
            string surname)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.Surname = surname;

            Validate(this);
        }

        /// <inheritdoc/>
        [ValidId]
        public Guid Id { get; }

        /// <inheritdoc/>
        [Required]
        [StringLength(
            maximumLength: Metadata.FirstName.MaxLength,
            MinimumLength = Metadata.FirstName.MinLength)]
        public string FirstName { get; }

        /// <inheritdoc/>
        [Required]
        [StringLength(
            maximumLength: Metadata.Surname.MaxLength,
            MinimumLength = Metadata.Surname.MinLength)]
        public string Surname { get; }
    }
}