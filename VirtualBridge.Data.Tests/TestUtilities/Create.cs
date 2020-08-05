﻿// <copyright file="Create.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Domain.Constants;

namespace VirtualBridge.Data.Tests.TestUtilities
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
        internal static AuditHeaderDto AuditHeader()
        {
            return new AuditHeaderDto(
                id: Guid.NewGuid(),
                auditEvent: EAuditEvent.OrganisationMaintenance,
                timeStamp: DateTime.Now,
                username: "Steve.Wright",
                correlationId: Guid.NewGuid(),
                auditDetails: new List<AuditDetailDto>());
        }

        /// <summary>
        /// Audits the detail.
        /// </summary>
        /// <param name="auditHeader">The audit header.</param>
        /// <returns>Audit Detail.</returns>
        internal static AuditDetailDto AuditDetail(AuditHeaderDto auditHeader)
        {
            return new AuditDetailDto(
                Guid.NewGuid(),
                auditHeader.Id,
                "TableName",
                "ColumnName",
                Guid.NewGuid(),
                "Old Value",
                "New Value",
                EDatabaseAction.Update,
                auditHeader);
        }
    }
}