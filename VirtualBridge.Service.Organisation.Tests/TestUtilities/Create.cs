// <copyright file="Create.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Service.Organisation.Tests.TestUtilities
{
    /// <summary>
    /// Create DTOs for tests.
    /// </summary>
    internal static class Create
    {
        /// <summary>
        /// Creates an <see cref="AuditHeaderDto"/>.
        /// </summary>
        /// <returns>Audit Header.</returns>
        internal static IOrganisation Organisation()
        {
            return new Domain.DomainObjects.Organisations.Organisation(
                id: Guid.NewGuid(),
                shortName: "Short",
                mediumName: "Medium",
                longName: "Long",
                code: "Code");
        }

        /// <summary>
        /// Create a <see cref="IWho"/>.
        /// </summary>
        /// <returns>Who details.</returns>
        internal static IWho Who()
        {
            return new Who(
                controllerName: "ControllerName",
                actionName: "ActionName",
                path: string.Empty,
                queryString: string.Empty);
        }
    }
}