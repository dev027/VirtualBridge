// <copyright file="Create.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;

namespace VirtualBridge.Domain.Tests.TestUtilities
{
    /// <summary>
    /// Create domain objects for tests.
    /// </summary>
    internal static class Create
    {
        /// <summary>
        /// Creates an <see cref="IAuditHeader"/>.
        /// </summary>
        /// <returns>Audit Header.</returns>
        internal static IAuditHeader AuditHeader()
        {
            return new AuditHeader(
                id: Guid.NewGuid(),
                auditEvent: EAuditEvent.OrganisationMaintenance,
                timeStamp: DateTime.Now,
                username: "Steve.Wright",
                correlationId: Guid.NewGuid());
        }
    }
}