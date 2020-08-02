// <copyright file="ToDtoWithAuditDetailsTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditDetails;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;

namespace VirtualBridge.Data.Tests.Dtos.AuditHeaderTests
{
    /// <summary>
    /// Test <see cref="AuditHeaderDto.ToDtoWithAuditDetails"/>.
    /// </summary>
    [TestClass]
    public class ToDtoWithAuditDetailsTests
    {
        /// <summary>
        /// Tests method with valid values.
        /// </summary>
        [TestMethod]
        public void Test_Passing_Valid_Values()
        {
            // ARRANGE
            IAuditHeaderWithAuditDetails auditHeader = new AuditHeaderWithAuditDetails(
                auditEvent: EAuditEvent.OrganisationMaintenance,
                username: "Steve.Wright",
                correlationId: Guid.NewGuid());

            IAuditDetail auditDetail = new AuditDetail(
                id: Guid.NewGuid(),
                auditHeader: auditHeader,
                tableName: "TableName",
                columnName: "ColumnName",
                recordId: Guid.NewGuid(),
                oldValue: "Old Value",
                newValue: "New Value",
                databaseAction: EDatabaseAction.Update);

            auditHeader.AuditDetails.Add(auditDetail);

            // ACT
            AuditHeaderDto auditHeaderDto = AuditHeaderDto.ToDtoWithAuditDetails(auditHeader);

            // ASSERT
            Assert.AreEqual(auditHeader.Id, auditHeaderDto.Id);
            Assert.AreEqual(auditHeader.AuditEvent, auditHeaderDto.AuditEvent);
            Assert.AreEqual(auditHeader.TimeStamp, auditHeaderDto.TimeStamp);
            Assert.AreEqual(auditHeader.Username, auditHeaderDto.Username);
            Assert.AreEqual(auditHeader.CorrelationId, auditHeaderDto.CorrelationId);
            Assert.IsNotNull(auditHeaderDto.AuditDetails);
        }

        /// <summary>
        /// Tests passing null AuditHeader throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Passing_Null_AuditHeader_Throws_Exception()
        {
            // ACT
            _ = AuditHeaderDto.ToDtoWithAuditDetails(null!);
        }
    }
}