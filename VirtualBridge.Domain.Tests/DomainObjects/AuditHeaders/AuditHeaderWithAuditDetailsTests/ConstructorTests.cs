// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditDetails;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;

namespace VirtualBridge.Domain.Tests.DomainObjects.AuditHeaders.AuditHeaderWithAuditDetailsTests
{
    /// <summary>
    /// Constructor tests for <see cref="IAuditHeaderWithAuditDetails"/>.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the constructor with valid values.
        /// </summary>
        [TestMethod]
        public void TestFullConstructorWithValidValues()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const EAuditEvent paramAuditEvent = EAuditEvent.OrganisationMaintenance;
            DateTime paramTimeStamp = DateTime.Now;
            const string paramUsername = "Steve.Wright";
            Guid paramCorrelationId = Guid.NewGuid();
            IList<IAuditDetail> paramAuditDetails = new List<IAuditDetail>();

            // ACT
            IAuditHeaderWithAuditDetails auditHeaderWithAuditDetails = new AuditHeaderWithAuditDetails(
                id: paramId,
                auditEvent: paramAuditEvent,
                timeStamp: paramTimeStamp,
                username: paramUsername,
                correlationId: paramCorrelationId,
                auditDetails: paramAuditDetails);

            // ASSERT
            Assert.AreNotEqual(Guid.Empty, auditHeaderWithAuditDetails.Id);
            Assert.AreEqual(paramId, auditHeaderWithAuditDetails.Id);
            Assert.AreEqual(paramAuditEvent, auditHeaderWithAuditDetails.AuditEvent);
            Assert.AreEqual(paramTimeStamp, auditHeaderWithAuditDetails.TimeStamp);
            Assert.AreEqual(paramUsername, auditHeaderWithAuditDetails.Username);
            Assert.AreNotEqual(Guid.Empty, auditHeaderWithAuditDetails.CorrelationId);
            Assert.AreEqual(paramCorrelationId, auditHeaderWithAuditDetails.CorrelationId);
            Assert.AreSame(paramAuditDetails, auditHeaderWithAuditDetails.AuditDetails);
        }

        /// <summary>
        /// Tests the constructor with valid values.
        /// </summary>
        [TestMethod]
        public void TestShortConstructorWithValidValues()
        {
            // ARRANGE
            const EAuditEvent paramAuditEvent = EAuditEvent.OrganisationMaintenance;
            const string paramUsername = "Steve.Wright";
            Guid paramCorrelationId = Guid.NewGuid();

            // ACT
            IAuditHeaderWithAuditDetails auditHeaderWithAuditDetails = new AuditHeaderWithAuditDetails(
                auditEvent: paramAuditEvent,
                username: paramUsername,
                correlationId: paramCorrelationId);

            // ASSERT
            double seconds = (DateTime.Now - auditHeaderWithAuditDetails.TimeStamp).TotalSeconds;
            Assert.AreNotEqual(Guid.Empty, auditHeaderWithAuditDetails.Id);
            Assert.AreEqual(paramAuditEvent, auditHeaderWithAuditDetails.AuditEvent);
            Assert.IsTrue(seconds >= 0 && seconds <= 5);
            Assert.AreEqual(paramUsername, auditHeaderWithAuditDetails.Username);
            Assert.AreNotEqual(Guid.Empty, auditHeaderWithAuditDetails.CorrelationId);
            Assert.AreEqual(paramCorrelationId, auditHeaderWithAuditDetails.CorrelationId);
            Assert.IsNotNull(auditHeaderWithAuditDetails.AuditDetails);
            Assert.AreEqual(0, auditHeaderWithAuditDetails.AuditDetails.Count);
        }
    }
}