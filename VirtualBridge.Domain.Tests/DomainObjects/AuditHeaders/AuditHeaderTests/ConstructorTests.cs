// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.Exceptions;

namespace VirtualBridge.Domain.Tests.DomainObjects.AuditHeaders.AuditHeaderTests
{
    /// <summary>
    /// Constructor tests for <see cref="IAuditHeader"/>.
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

            // ACT
            IAuditHeader auditHeader = new AuditHeader(
                id: paramId,
                auditEvent: paramAuditEvent,
                timeStamp: paramTimeStamp,
                username: paramUsername,
                correlationId: paramCorrelationId);

            // ASSERT
            Assert.AreNotEqual(Guid.Empty, auditHeader.Id);
            Assert.AreEqual(paramId, auditHeader.Id);
            Assert.AreEqual(paramAuditEvent, auditHeader.AuditEvent);
            Assert.AreEqual(paramTimeStamp, auditHeader.TimeStamp);
            Assert.AreEqual(paramUsername, auditHeader.Username);
            Assert.AreNotEqual(Guid.Empty, auditHeader.CorrelationId);
            Assert.AreEqual(paramCorrelationId, auditHeader.CorrelationId);
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
            IAuditHeader auditHeader = new AuditHeader(
                auditEvent: paramAuditEvent,
                username: paramUsername,
                correlationId: paramCorrelationId);

            // ASSERT
            double seconds = (DateTime.Now - auditHeader.TimeStamp).TotalSeconds;
            Assert.AreNotEqual(Guid.Empty, auditHeader.Id);
            Assert.AreEqual(paramAuditEvent, auditHeader.AuditEvent);
            Assert.IsTrue(seconds >= 0 && seconds <= 5);
            Assert.AreEqual(paramUsername, auditHeader.Username);
            Assert.AreNotEqual(Guid.Empty, auditHeader.CorrelationId);
            Assert.AreEqual(paramCorrelationId, auditHeader.CorrelationId);
        }

        #region Property: Id

        /// <summary>
        /// Tests that an empty audit header id throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyAuditHeaderIdThrowsException()
        {
            // ARRANGE
            const EAuditEvent paramAuditEvent = EAuditEvent.OrganisationMaintenance;
            DateTime paramTimeStamp = DateTime.Now;
            const string paramUsername = "Steve.Wright";
            Guid paramCorrelationId = Guid.NewGuid();

            // ACT
            _ = new AuditHeader(
                id: Guid.Empty,
                auditEvent: paramAuditEvent,
                timeStamp: paramTimeStamp,
                username: paramUsername,
                correlationId: paramCorrelationId);
        }

        #endregion Property: Id

        #region Property: Username

        /// <summary>
        /// Tests that a null username throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullUsernameThrowsException()
        {
            // ARRANGE
            const EAuditEvent paramAuditEvent = EAuditEvent.OrganisationMaintenance;
            Guid paramCorrelationId = Guid.NewGuid();

            // ACT
            _ = new AuditHeader(
                auditEvent: paramAuditEvent,
                username: null!,
                correlationId: paramCorrelationId);
        }

        /// <summary>
        /// Tests that a empty username throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyUsernameThrowsException()
        {
            // ARRANGE
            const EAuditEvent paramAuditEvent = EAuditEvent.OrganisationMaintenance;
            Guid paramCorrelationId = Guid.NewGuid();

            // ACT
            _ = new AuditHeader(
                auditEvent: paramAuditEvent,
                username: string.Empty,
                correlationId: paramCorrelationId);
        }

        /// <summary>
        /// Tests that a long username throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongUsernameThrowsException()
        {
            // ARRANGE
            const EAuditEvent paramAuditEvent = EAuditEvent.OrganisationMaintenance;
            string paramUsername = new string('x', 500);
            Guid paramCorrelationId = Guid.NewGuid();

            // ACT
            _ = new AuditHeader(
                auditEvent: paramAuditEvent,
                username: paramUsername,
                correlationId: paramCorrelationId);
        }

        #endregion Property: Username

        #region Property: CorrelationId

        /// <summary>
        /// Tests that an empty correlation id throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyCorrelationIdThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const EAuditEvent paramAuditEvent = EAuditEvent.OrganisationMaintenance;
            DateTime paramTimeStamp = DateTime.Now;
            const string paramUsername = "Steve.Wright";

            // ACT
            _ = new AuditHeader(
                id: paramId,
                auditEvent: paramAuditEvent,
                timeStamp: paramTimeStamp,
                username: paramUsername,
                correlationId: Guid.Empty);
        }

        #endregion Property: CorrelationId
    }
}