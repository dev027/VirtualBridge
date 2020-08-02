// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Domain.Constants;

namespace VirtualBridge.Data.Tests.Dtos.AuditHeaderTests
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
            AuditHeaderDto auditHeaderDto = new AuditHeaderDto();

            // ASSERT
            Assert.AreEqual(Guid.Empty, auditHeaderDto.Id);
            Assert.AreEqual(EAuditEvent.Unknown, auditHeaderDto.AuditEvent);
            Assert.AreEqual(DateTime.MinValue, auditHeaderDto.TimeStamp);
            Assert.AreEqual(null, auditHeaderDto.Username);
            Assert.AreEqual(Guid.Empty, auditHeaderDto.CorrelationId);
            Assert.IsNull(auditHeaderDto.AuditDetails);
        }

        /// <summary>
        /// Tests the basic constructor.
        /// </summary>
        [TestMethod]
        public void Test_Basic_Constructor()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const EAuditEvent paramAuditEvent = EAuditEvent.OrganisationMaintenance;
            DateTime paramTimeStamp = DateTime.Now;
            const string paramUsername = "Steve.Wright";
            Guid paramCorrelationId = Guid.NewGuid();
            IList<AuditDetailDto> paramAuditDetails = new List<AuditDetailDto>
            {
                new AuditDetailDto(
                    id: Guid.NewGuid(),
                    auditHeaderId: paramId,
                    tableName: "TableName",
                    columnName: "ColumnName",
                    recordId: Guid.NewGuid(),
                    oldValue: "old value",
                    newValue: "new value",
                    databaseAction: EDatabaseAction.Update)
            };

            // ACT
            AuditHeaderDto auditHeaderDto = new AuditHeaderDto(
                id: paramId,
                auditEvent: paramAuditEvent,
                timeStamp: paramTimeStamp,
                username: paramUsername,
                correlationId: paramCorrelationId,
                auditDetails: paramAuditDetails);

            // ASSERT
            Assert.AreEqual(paramId, auditHeaderDto.Id);
            Assert.AreEqual(paramAuditEvent, auditHeaderDto.AuditEvent);
            Assert.AreEqual(paramTimeStamp, auditHeaderDto.TimeStamp);
            Assert.AreEqual(paramUsername, auditHeaderDto.Username);
            Assert.AreEqual(paramCorrelationId, auditHeaderDto.CorrelationId);
            Assert.AreSame(paramAuditDetails, auditHeaderDto.AuditDetails);
        }
    }
}