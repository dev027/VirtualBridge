// <copyright file="ICompetition.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using VirtualBridge.Domain.DomainObjects.Organisations;

namespace VirtualBridge.Domain.DomainObjects.Competitions
{
    /// <summary>
    /// Competition.
    /// </summary>
    public interface ICompetition
    {
        /// <summary>
        /// Gets the Competition Id.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the Competition Name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the Description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the Organisation.
        /// </summary>
        IOrganisation Organisation { get; }
    }
}