// <copyright file="CreateForDeleteTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditDetails;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.Tests.TestUtilities;

namespace VirtualBridge.Domain.Tests.DomainObjects.AuditDetails.AuditDetailsTests
{
    /// <summary>
    /// Tests for <see cref="AuditDetail.CreateForDelete"/>.
    /// </summary>
    [TestClass]
    public class CreateForDeleteTests
    {
        /// <summary>
        /// Tests with valid values.
        /// </summary>
        [TestMethod]
        public void TestWithValidValues()
        {
            // ARRANGE
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            const string paramTableName = "Organisation";
            Guid paramRecordId = Guid.NewGuid();

            // ACT
            IAuditDetail auditDetail = AuditDetail.CreateForDelete(
                auditHeader: paramAuditHeader,
                tableName: paramTableName,
                recordId: paramRecordId);

            // ASSERT
            Assert.IsNotNull(auditDetail);
            Assert.AreNotEqual(paramRecordId, auditDetail.Id);
            Assert.AreSame(paramAuditHeader, auditDetail.AuditHeader);
            Assert.AreEqual(paramTableName, auditDetail.TableName);
            Assert.AreEqual("Id", auditDetail.ColumnName);
            Assert.AreEqual(paramRecordId, auditDetail.RecordId);
            Assert.AreEqual(paramRecordId.ToString(), auditDetail.OldValue);
            Assert.IsNull(auditDetail.NewValue);
            Assert.AreEqual(EDatabaseAction.Delete, auditDetail.DatabaseAction);
        }
    }
}