// <copyright file="ToDomainTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Data.Tests.TestUtilities;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;

namespace VirtualBridge.Data.Tests.Dtos.AuditHeaderTests
{
    /// <summary>
    /// Test <see cref="AuditHeaderDto.ToDomain"/>.
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

            // ACT
            IAuditHeader auditHeader = auditHeaderDto.ToDomain();

            // ASSERT
            Assert.IsNotNull(auditHeader);
            Assert.AreEqual(auditHeaderDto.Id, auditHeader.Id);
            Assert.AreEqual(auditHeaderDto.AuditEvent, auditHeader.AuditEvent);
            Assert.AreEqual(auditHeaderDto.TimeStamp, auditHeader.TimeStamp);
            Assert.AreEqual(auditHeaderDto.Username, auditHeader.Username);
            Assert.AreEqual(auditHeaderDto.CorrelationId, auditHeader.CorrelationId);
        }
    }
}