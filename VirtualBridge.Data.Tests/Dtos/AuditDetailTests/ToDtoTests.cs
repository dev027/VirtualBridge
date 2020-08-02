// <copyright file="ToDtoTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditDetails;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;

namespace VirtualBridge.Data.Tests.Dtos.AuditDetailTests
{
    /// <summary>
    /// Test <see cref="OrganisationDto.ToDto"/>.
    /// </summary>
    [TestClass]
    public class ToDtoTests
    {
        /// <summary>
        /// Tests method with valid values.
        /// </summary>
        [TestMethod]
        public void Test_Passing_Valid_Values()
        {
            // ARRANGE
            IAuditHeader auditHeader = new AuditHeader(
                id: Guid.NewGuid(),
                auditEvent: EAuditEvent.OrganisationMaintenance,
                timeStamp: DateTime.Now,
                username: "Steve.Wright",
                correlationId: Guid.NewGuid());
            IAuditDetail auditDetail = new AuditDetail(
                Guid.NewGuid(),
                auditHeader,
                "TableName",
                "ColumnName",
                Guid.NewGuid(),
                "Old Value",
                "New Value",
                EDatabaseAction.Update);

            // ACT
            AuditDetailDto auditDetailDto = AuditDetailDto.ToDto(auditDetail);

            // ASSERT
            Assert.AreEqual(auditDetail.Id, auditDetailDto.Id);
            Assert.AreEqual(auditDetail.AuditHeader.Id, auditDetailDto.AuditHeaderId);
            Assert.AreEqual(auditDetail.TableName, auditDetailDto.TableName);
            Assert.AreEqual(auditDetail.ColumnName, auditDetailDto.ColumnName);
            Assert.AreEqual(auditDetail.RecordId, auditDetailDto.RecordId);
            Assert.AreEqual(auditDetail.OldValue, auditDetailDto.OldValue);
            Assert.AreEqual(auditDetail.NewValue, auditDetailDto.NewValue);
            Assert.AreEqual(auditDetail.DatabaseAction, auditDetailDto.DatabaseAction);
        }

        /// <summary>
        /// Tests passing null Audit Header throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Passing_Null_AuditDetail_Throws_Exception()
        {
            // ACT
            _ = AuditDetailDto.ToDto(null!);
        }
    }
}