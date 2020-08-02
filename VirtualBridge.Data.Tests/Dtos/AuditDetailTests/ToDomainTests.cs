// <copyright file="ToDomainTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Data.Tests.TestUtilities;
using VirtualBridge.Domain.DomainObjects.AuditDetails;

namespace VirtualBridge.Data.Tests.Dtos.AuditDetailTests
{
    /// <summary>
    /// Test <see cref="AuditDetailDto.ToDomain" />.
    /// </summary>
    [TestClass]
    public class ToDomainTests
    {
        /// <summary>
        /// Tests passing valid values.
        /// </summary>
        [TestMethod]
        public void Test_Passing_Valid_Values()
        {
            // ARRANGE
            AuditHeaderDto auditHeaderDto = Create.AuditHeader();
            AuditDetailDto auditDetailDto = Create.AuditDetail(auditHeaderDto);

            // ACT
            IAuditDetail auditDetail = auditDetailDto.ToDomain();

            // ASSERT
            Assert.IsNotNull(auditDetail);
            Assert.AreEqual(auditDetailDto.Id, auditDetail.Id);
            Assert.AreEqual(auditDetailDto.AuditHeaderId, auditDetail.AuditHeader.Id);
            Assert.AreEqual(auditDetailDto.TableName, auditDetail.TableName);
            Assert.AreEqual(auditDetailDto.ColumnName, auditDetail.ColumnName);
            Assert.AreEqual(auditDetailDto.RecordId, auditDetail.RecordId);
            Assert.AreEqual(auditDetailDto.OldValue, auditDetail.OldValue);
            Assert.AreEqual(auditDetailDto.NewValue, auditDetail.NewValue);
            Assert.AreEqual(auditDetailDto.DatabaseAction, auditDetail.DatabaseAction);
        }

        /// <summary>
        /// Tests with null audit header throws exception.
        /// </summary>
        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void Test_With_Null_AuditHeader_Throws_Exception()
        {
            // ARRANGE
            AuditHeaderDto auditHeaderDto = Create.AuditHeader();
            AuditDetailDto auditDetailDto = Create.AuditDetail(auditHeaderDto);
            auditDetailDto.SetPrivatePropertyValue(
                propName: nameof(AuditDetailDto.AuditHeader),
                value: (AuditHeaderDto)null);

            // ACT
            _ = auditDetailDto.ToDomain();
        }
    }
}