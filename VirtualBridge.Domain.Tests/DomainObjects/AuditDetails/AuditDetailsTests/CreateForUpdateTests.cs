// <copyright file="CreateForUpdateTests.cs" company="Do It Wright">
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
    /// Tests for <see cref="AuditDetail.CreateForUpdate"/>.
    /// </summary>
    [TestClass]
    public class CreateForUpdateTests
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
            const string paramColumnName = "Id";
            Guid paramRecordId = Guid.NewGuid();
            const string paramNewValue = "New Value";
            const string paramOldValue = "Old Value";

            // ACT
            IAuditDetail auditDetail = AuditDetail.CreateForUpdate(
                paramAuditHeader,
                paramTableName,
                paramColumnName,
                paramRecordId,
                paramOldValue,
                paramNewValue);

            // ASSERT
            Assert.IsNotNull(auditDetail);
            Assert.AreNotEqual(paramRecordId, auditDetail.Id);
            Assert.AreSame(paramAuditHeader, auditDetail.AuditHeader);
            Assert.AreEqual(paramTableName, auditDetail.TableName);
            Assert.AreEqual(paramColumnName, auditDetail.ColumnName);
            Assert.AreEqual(paramRecordId, auditDetail.RecordId);
            Assert.AreEqual(paramOldValue, auditDetail.OldValue);
            Assert.AreEqual(paramNewValue, auditDetail.NewValue);
            Assert.AreEqual(EDatabaseAction.Update, auditDetail.DatabaseAction);
        }
    }
}