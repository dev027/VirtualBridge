// <copyright file="HostDto.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualBridge.Data.DbContexts;
using VirtualBridge.Domain.DomainObjects.Hosts;

namespace VirtualBridge.Data.Dtos
{
    /// <summary>
    /// Host DTO.
    /// </summary>
    [Table(nameof(DataContext.Hosts))]
    public class HostDto : BaseDto
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HostDto"/> class.
        /// </summary>
        public HostDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HostDto"/> class.
        /// </summary>
        /// <param name="id">Host Id.</param>
        /// <param name="firstName">First Name.</param>
        /// <param name="surname">Surname.</param>
        public HostDto(
            Guid id,
            string firstName,
            string surname)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.Surname = surname;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the Host Id.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the First Name.
        /// </summary>
        [Required]
        [MaxLength(Domain.DomainObjects.Hosts.Metadata.FirstName.MaxLength)]
        public string FirstName { get; private set; } = null!;

        /// <summary>
        /// Gets the Surname.
        /// </summary>
        [Required]
        [MaxLength(Domain.DomainObjects.Hosts.Metadata.Surname.MaxLength)]
        public string Surname { get; private set; } = null!;

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Converts domain object to DTO.
        /// </summary>
        /// <param name="host">Host.</param>
        /// <returns>Host DTO.</returns>
        public static HostDto ToDto(IHost host)
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            return new HostDto(
                id: host.Id,
                firstName: host.FirstName,
                surname: host.Surname);
        }

        /// <summary>
        /// Converts instance to domain object.
        /// </summary>
        /// <returns>Host.</returns>
        public IHost ToDomain()
        {
            return new Host(
                id: this.Id,
                firstName: this.FirstName,
                surname: this.Surname);
        }

        #endregion
    }
}