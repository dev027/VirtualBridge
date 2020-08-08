// <copyright file="Create.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Utilities.Models.Whos;

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
        /// Creates an <see cref="AuditDetailDto"/>.
        /// </summary>
        /// <param name="auditHeader">The audit header.</param>
        /// <returns>Audit Detail.</returns>
        internal static AuditDetailDto AuditDetail(AuditHeaderDto auditHeader)
        {
            return new AuditDetailDto(
                id: Guid.NewGuid(),
                auditHeaderId: auditHeader.Id,
                tableName: "TableName",
                columnName: "ColumnName",
                recordId: Guid.NewGuid(),
                oldValue: "Old Value",
                newValue: "New Value",
                databaseAction: EDatabaseAction.Update,
                auditHeader: auditHeader);
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