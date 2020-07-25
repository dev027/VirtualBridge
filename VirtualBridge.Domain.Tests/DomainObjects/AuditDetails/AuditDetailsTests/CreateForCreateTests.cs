// <copyright file="CreateForCreateTests.cs" company="Do It Wright">
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
    /// Tests for <see cref="AuditDetail.CreateForCreate"/>.
    /// </summary>
    [TestClass]
    public class CreateForCreateTests
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

            // ACT
            IAuditDetail auditDetail = AuditDetail.CreateForCreate(
                paramAuditHeader,
                paramTableName,
                paramColumnName,
                paramRecordId,
                paramNewValue);

            // ASSERT
            Assert.IsNotNull(auditDetail);
            Assert.AreNotEqual(paramRecordId, auditDetail.Id);
            Assert.AreSame(paramAuditHeader, auditDetail.AuditHeader);
            Assert.AreEqual(paramTableName, auditDetail.TableName);
            Assert.AreEqual(paramColumnName, auditDetail.ColumnName);
            Assert.AreEqual(paramRecordId, auditDetail.RecordId);
            Assert.IsNull(auditDetail.OldValue);
            Assert.AreEqual(paramNewValue, auditDetail.NewValue);
            Assert.AreEqual(EDatabaseAction.Create, auditDetail.DatabaseAction);
        }
    }
}