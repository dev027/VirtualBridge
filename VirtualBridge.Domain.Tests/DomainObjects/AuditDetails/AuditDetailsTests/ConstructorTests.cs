// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditDetails;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.Exceptions;
using VirtualBridge.Domain.Tests.TestUtilities;

namespace VirtualBridge.Domain.Tests.DomainObjects.AuditDetails.AuditDetailsTests
{
    /// <summary>
    /// Constructor tests for <see cref="IAuditDetail"/>.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests with valid values.
        /// </summary>
        [TestMethod]
        public void TestWithValidValues()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            const string paramTableName = "Organisation";
            const string paramColumnName = "Id";
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "New Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            IAuditDetail auditDetail = new AuditDetail(
                id: paramId,
                auditHeader: paramAuditHeader,
                tableName: paramTableName,
                columnName: paramColumnName,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);

            // ASSERT
            Assert.AreEqual(paramId, auditDetail.Id);
            Assert.AreSame(paramAuditHeader, auditDetail.AuditHeader);
            Assert.AreEqual(paramTableName, auditDetail.TableName);
            Assert.AreEqual(paramColumnName, auditDetail.ColumnName);
            Assert.AreEqual(paramRecordId, auditDetail.RecordId);
            Assert.AreEqual(paramOldValue, auditDetail.OldValue);
            Assert.AreEqual(paramNewValue, auditDetail.NewValue);
            Assert.AreEqual(paramDatabaseAction, auditDetail.DatabaseAction);
        }

        /// <summary>
        /// Tests the with valid values that are null.
        /// </summary>
        [TestMethod]
        public void TestWithValidValuesThatAreNull()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            const string paramTableName = "Organisation";
            const string paramColumnName = "Id";
            Guid paramRecordId = Guid.NewGuid();
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            IAuditDetail auditDetail = new AuditDetail(
                id: paramId,
                auditHeader: paramAuditHeader,
                tableName: paramTableName,
                columnName: paramColumnName,
                recordId: paramRecordId,
                oldValue: null,
                newValue: null,
                databaseAction: paramDatabaseAction);

            // ASSERT
            Assert.IsNull(auditDetail.OldValue);
            Assert.IsNull(auditDetail.NewValue);
        }

        #region Property: Id

        /// <summary>
        /// Tests that empty audit detail id throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyAuditDetailIdThrowsException()
        {
            // ARRANGE
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            const string paramTableName = "Organisation";
            const string paramColumnName = "Id";
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "New Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            _ = new AuditDetail(
                id: Guid.Empty,
                auditHeader: paramAuditHeader,
                tableName: paramTableName,
                columnName: paramColumnName,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);
        }

        #endregion Property: Id

        #region Property: AuditHeader

        /// <summary>
        /// Tests that null audit header throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullAuditHeaderThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramTableName = "Organisation";
            const string paramColumnName = "Id";
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "New Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            _ = new AuditDetail(
                id: paramId,
                auditHeader: null!,
                tableName: paramTableName,
                columnName: paramColumnName,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);
        }

        #endregion Property: AuditHeader

        #region Property: TableName

        /// <summary>
        /// Tests that null table name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullTableNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            const string paramColumnName = "Id";
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "New Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            _ = new AuditDetail(
                id: paramId,
                auditHeader: paramAuditHeader,
                tableName: null!,
                columnName: paramColumnName,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);
        }

        /// <summary>
        /// Tests that empty table name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyTableNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            const string paramColumnName = "Id";
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "New Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            _ = new AuditDetail(
                id: paramId,
                auditHeader: paramAuditHeader,
                tableName: string.Empty,
                columnName: paramColumnName,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);
        }

        /// <summary>
        /// Tests that long table name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongTableNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            string paramTableName = new string('x', 500);
            const string paramColumnName = "Id";
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "New Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            _ = new AuditDetail(
                id: paramId,
                auditHeader: paramAuditHeader,
                tableName: paramTableName,
                columnName: paramColumnName,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);
        }

        #endregion Property: TableName

        #region Property: ColumnName

        /// <summary>
        /// Tests that null column name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullColumnNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            const string paramTableName = "Organisation";
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "New Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            _ = new AuditDetail(
                id: paramId,
                auditHeader: paramAuditHeader,
                tableName: paramTableName,
                columnName: null!,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);
        }

        /// <summary>
        /// Tests that empty column name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyColumnNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            const string paramTableName = "Organisation";
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "New Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            _ = new AuditDetail(
                id: paramId,
                auditHeader: paramAuditHeader,
                tableName: paramTableName,
                columnName: string.Empty,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);
        }

        /// <summary>
        /// Tests that long column name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongColumnNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            const string paramTableName = "Organisation";
            string paramColumnName = new string('x', 500);
            Guid paramRecordId = Guid.NewGuid();
            const string paramOldValue = "Old Value";
            const string paramNewValue = "New Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            _ = new AuditDetail(
                id: paramId,
                auditHeader: paramAuditHeader,
                tableName: paramTableName,
                columnName: paramColumnName,
                recordId: paramRecordId,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);
        }

        #endregion Property: ColumnName

        #region Property: RecordId

        /// <summary>
        /// Tests that empty record id throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyRecordIdThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            IAuditHeader paramAuditHeader = Create.AuditHeader();
            const string paramTableName = "Organisation";
            const string paramColumnName = "Id";
            const string paramOldValue = "Old Value";
            const string paramNewValue = "New Value";
            const EDatabaseAction paramDatabaseAction = EDatabaseAction.Update;

            // ACT
            _ = new AuditDetail(
                id: paramId,
                auditHeader: paramAuditHeader,
                tableName: paramTableName,
                columnName: paramColumnName,
                recordId: Guid.Empty,
                oldValue: paramOldValue,
                newValue: paramNewValue,
                databaseAction: paramDatabaseAction);
        }

        #endregion Property: RecordId
    }
}