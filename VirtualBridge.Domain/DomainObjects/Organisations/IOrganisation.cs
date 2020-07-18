// <copyright file="IOrganisation.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;

namespace VirtualBridge.Domain.DomainObjects.Organisations
{
    /// <summary>
    /// Organisation.
    /// </summary>
    public interface IOrganisation
    {
        /// <summary>
        /// Gets the Organisation Id.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the Short Name.
        /// </summary>
        string ShortName { get; }

        /// <summary>
        /// Gets the Medium Name.
        /// </summary>
        string MediumName { get; }

        /// <summary>
        /// Gets the Long Name.
        /// </summary>
        string LongName { get; }

        /// <summary>
        /// Gets the Code.
        /// </summary>
        string Code { get; }
    }
}