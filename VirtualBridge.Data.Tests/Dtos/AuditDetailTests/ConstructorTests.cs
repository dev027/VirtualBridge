// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Domain.Constants;

namespace VirtualBridge.Data.Tests.Dtos.AuditDetailTests
{
    /// <summary>
    /// Test constructor for <see cref="AuditHeaderDto" />.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the default constructor.
        /// </summary>
        [TestMethod]
        public void Test_Default_Constructor()
        {
            // ACT
            AuditDetailDto auditDetailDto = new AuditDetailDto();

            // ASSERT
            Assert.AreEqual(Guid.Empty, auditDetailDto.Id);
            Assert.AreEqual(Guid.Empty, auditDetailDto.AuditHeaderId);
            Assert.AreEqual(null, auditDetailDto.TableName);
            Assert.AreEqual(null, auditDetailDto.ColumnName);
            Assert.AreEqual(Guid.Empty, auditDetailDto.RecordId);
            Assert.IsNull(auditDetailDto.OldValue);
            Assert.IsNull(auditDetailDto.NewValue);
            Assert.AreEqual(EDatabaseAction.Create, auditDetailDto.DatabaseAction);
            Assert.IsNull(auditDetailDto.AuditHeader);
        }

        /// <summary>
        /// Tests the basic constructor.
        /// </summary>
        [TestMethod]
        public void Test_Basic_Constructor()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            Guid paramAuditHeaderId = Guid.NewGuid();
            const string paramTableName = "TableName";
            const string paramColumnName = "ColumnName";
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "new Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            AuditDetailDto auditDetailDto = new AuditDetailDto(
                id: paramId,
                auditHeaderId: paramAuditHeaderId,
                tableName: paramTableName,
                columnName: paramColumnName,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);

            // ASSERT
            Assert.AreEqual(paramId, auditDetailDto.Id);
            Assert.AreEqual(paramAuditHeaderId, auditDetailDto.AuditHeaderId);
            Assert.AreEqual(paramTableName, auditDetailDto.TableName);
            Assert.AreEqual(paramColumnName, auditDetailDto.ColumnName);
            Assert.AreEqual(paramRecordId, auditDetailDto.RecordId);
            Assert.AreEqual(paramOldValue, auditDetailDto.OldValue);
            Assert.AreEqual(paramNewValue, auditDetailDto.NewValue);
            Assert.AreEqual(paramDatabaseAction, auditDetailDto.DatabaseAction);
            Assert.IsNull(auditDetailDto.AuditHeader);
        }

        /// <summary>
        /// Tests the full constructor.
        /// </summary>
        [TestMethod]
        public void Test_Full_Constructor()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            AuditHeaderDto paramAuditHeaderDto = new AuditHeaderDto(
                Guid.NewGuid(),
                EAuditEvent.OrganisationMaintenance,
                DateTime.Now,
                "Steve.Wright",
                Guid.NewGuid(),
                new List<AuditDetailDto>());
            const string paramTableName = "TableName";
            const string paramColumnName = "ColumnName";
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "new Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            AuditDetailDto auditDetailDto = new AuditDetailDto(
                id: paramId,
                auditHeaderId: paramAuditHeaderDto.Id,
                tableName: paramTableName,
                columnName: paramColumnName,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction,
                auditHeader: paramAuditHeaderDto);

            // ASSERT
            Assert.AreEqual(paramId, auditDetailDto.Id);
            Assert.AreEqual(paramAuditHeaderDto.Id, auditDetailDto.AuditHeaderId);
            Assert.AreEqual(paramTableName, auditDetailDto.TableName);
            Assert.AreEqual(paramColumnName, auditDetailDto.ColumnName);
            Assert.AreEqual(paramRecordId, auditDetailDto.RecordId);
            Assert.AreEqual(paramOldValue, auditDetailDto.OldValue);
            Assert.AreEqual(paramNewValue, auditDetailDto.NewValue);
            Assert.AreEqual(paramDatabaseAction, auditDetailDto.DatabaseAction);
            Assert.AreEqual(paramAuditHeaderDto, auditDetailDto.AuditHeader);
        }
    }
}