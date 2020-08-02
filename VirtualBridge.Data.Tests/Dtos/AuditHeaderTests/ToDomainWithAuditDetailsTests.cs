// <copyright file="ToDomainWithAuditDetailsTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Data.Tests.TestUtilities;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;

namespace VirtualBridge.Data.Tests.Dtos.AuditHeaderTests
{
    /// <summary>
    /// Test <see cref="AuditHeaderDto.ToDomainWithAuditDetails"/>.
    /// </summary>
    [TestClass]
    public class ToDomainWithAuditDetailsTests
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
            auditHeaderDto.SetPrivatePropertyValue(
                propName: nameof(AuditHeaderDto.AuditDetails),
                value: new List<AuditDetailDto>
                {
                    auditDetailDto
                });

            // ACT
            IAuditHeaderWithAuditDetails auditHeader = auditHeaderDto.ToDomainWithAuditDetails();

            // ASSERT
            Assert.IsNotNull(auditHeader);
            Assert.AreEqual(auditHeader.Id, auditHeader.Id);
            Assert.AreEqual(auditHeader.AuditEvent, auditHeader.AuditEvent);
            Assert.AreEqual(auditHeader.TimeStamp, auditHeader.TimeStamp);
            Assert.AreEqual(auditHeader.Username, auditHeader.Username);
            Assert.AreEqual(auditHeader.CorrelationId, auditHeader.CorrelationId);
            Assert.IsNotNull(auditHeader.AuditDetails);
            Assert.AreEqual(1, auditHeader.AuditDetails.Count);
        }
    }
}