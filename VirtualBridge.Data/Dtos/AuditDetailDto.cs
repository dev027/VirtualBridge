﻿// <copyright file="AuditDetailDto.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

#nullable enable
using System;
using System.Globalization;
using VirtualBridge.Data.Resources;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditDetails;

namespace VirtualBridge.Data.Dtos
{
    /// <summary>
    /// Audit Details DTO.
    /// </summary>
    public class AuditDetailDto
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditDetailDto"/> class.
        /// </summary>
        public AuditDetailDto()
        {
            this.TableName = null!;
            this.ColumnName = null!;
            this.DatabaseAction = EDatabaseAction.Create; // Any value will do
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditDetailDto"/> class.
        /// </summary>
        /// <param name="id">Audit Detail Id.</param>
        /// <param name="auditHeaderId">Audit Header Id.</param>
        /// <param name="tableName">Table Name.</param>
        /// <param name="columnName">Column Name.</param>
        /// <param name="recordId">Record Id.</param>
        /// <param name="oldValue">Old Value.</param>
        /// <param name="newValue">New Value.</param>
        /// <param name="databaseAction">Database Action.</param>
        public AuditDetailDto(
            Guid id,
            Guid auditHeaderId,
            string tableName,
            string columnName,
            Guid recordId,
            string? oldValue,
            string? newValue,
            EDatabaseAction databaseAction)
        {
            this.Id = id;
            this.AuditHeaderId = auditHeaderId;
            this.TableName = tableName;
            this.ColumnName = columnName;
            this.RecordId = recordId;
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.DatabaseAction = databaseAction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditDetailDto"/> class.
        /// </summary>
        /// <param name="id">Audit Detail Id.</param>
        /// <param name="auditHeaderId">Audit Header Id.</param>
        /// <param name="tableName">Table Name.</param>
        /// <param name="columnName">Column Name.</param>
        /// <param name="recordId">Record Id.</param>
        /// <param name="oldValue">Old Value.</param>
        /// <param name="newValue">New Value.</param>
        /// <param name="databaseAction">Database Action.</param>
        /// <param name="auditHeader">Audit Header.</param>
        public AuditDetailDto(
            Guid id,
            Guid auditHeaderId,
            string tableName,
            string columnName,
            Guid recordId,
            string oldValue,
            string newValue,
            EDatabaseAction databaseAction,
            AuditHeaderDto auditHeader)
        {
            this.Id = id;
            this.AuditHeaderId = auditHeaderId;
            this.TableName = tableName;
            this.ColumnName = columnName;
            this.RecordId = recordId;
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.DatabaseAction = databaseAction;
            this.AuditHeader = auditHeader;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the Audit Detail Id.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the Audit Header Id.
        /// </summary>
        public Guid AuditHeaderId { get; private set; }

        /// <summary>
        /// Gets the Table Name.
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// Gets the Column Name.
        /// </summary>
        public string ColumnName { get; private set; }

        /// <summary>
        /// Gets the Record Id.
        /// </summary>
        public Guid RecordId { get; private set; }

        /// <summary>
        /// Gets the Old Value.
        /// </summary>
        public string? OldValue { get; private set; }

        /// <summary>
        /// Gets the New Value.
        /// </summary>
        public string? NewValue { get; private set; }

        /// <summary>
        /// Gets the Database Action.
        /// </summary>
        public EDatabaseAction DatabaseAction { get; private set; }

        #endregion Properties

        #region Parent Properties

        /// <summary>
        /// Gets the Audit Header.
        /// </summary>
        public AuditHeaderDto AuditHeader { get; private set; } = null!;

        #endregion Parent Properties

        #region Public Methods

        /// <summary>
        /// Converts domain object to DTO.
        /// </summary>
        /// <param name="auditDetail">Audit Detail.</param>
        /// <returns>Audit Detail DTO.</returns>
        public static AuditDetailDto ToDto(IAuditDetail auditDetail)
        {
            if (auditDetail == null)
            {
                throw new ArgumentNullException(nameof(auditDetail));
            }

            return new AuditDetailDto(
                id: auditDetail.Id,
                auditHeaderId: auditDetail.AuditHeader.Id,
                tableName: auditDetail.TableName,
                columnName: auditDetail.ColumnName,
                recordId: auditDetail.RecordId,
                oldValue: auditDetail.OldValue,
                newValue: auditDetail.NewValue,
                databaseAction: auditDetail.DatabaseAction);
        }

        /// <summary>
        /// Converts instance to domain object.
        /// </summary>
        /// <returns>Audit Detail.</returns>
        public IAuditDetail ToDomain()
        {
            if (this.AuditHeader == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        ExceptionResource.CannotConvertTo___If___IsNull,
                        nameof(IAuditDetail),
                        nameof(this.AuditHeader)));
            }

            return new AuditDetail(
                id: this.Id,
                auditHeader: this.AuditHeader.ToDomain(),
                tableName: this.TableName,
                columnName: this.ColumnName,
                recordId: this.RecordId,
                oldValue: this.OldValue,
                newValue: this.NewValue,
                databaseAction: this.DatabaseAction);
        }

        #endregion
    }
}