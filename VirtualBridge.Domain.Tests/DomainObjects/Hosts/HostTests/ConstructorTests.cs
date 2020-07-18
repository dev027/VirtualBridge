// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.DomainObjects.Hosts;
using VirtualBridge.Domain.Exceptions;

namespace VirtualBridge.Domain.Tests.DomainObjects.Hosts.HostTests
{
    /// <summary>
    /// Constructor tests for <see cref="IHost"/>.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the constructor with valid values.
        /// </summary>
        [TestMethod]
        public void TestConstructorWithValidValues()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramFirstName = "Steve";
            const string paramSurname = "Wright";

            // ACT
            IHost host = new Host(
                id: paramId,
                firstName: paramFirstName,
                surname: paramSurname);

            // ASSERT
            Assert.IsNotNull(host);
            Assert.AreNotEqual(Guid.Empty, host.Id);
            Assert.AreEqual(paramId, host.Id);
            Assert.AreEqual(paramFirstName, host.FirstName);
            Assert.AreEqual(paramSurname, host.Surname);
        }

        #region Property: Id

        /// <summary>
        /// Tests that an empty unique identifier throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyGuidThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.Empty;
            const string paramFirstName = "Steve";
            const string paramSurname = "Wright";

            // ACT
            _ = new Host(
                id: paramId,
                firstName: paramFirstName,
                surname: paramSurname);
        }

        #endregion Property: Id

        #region Property: FirstName

        /// <summary>
        /// Tests that a null first name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullFirstNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramSurname = "Wright";

            // ACT
            _ = new Host(
                id: paramId,
                firstName: null!,
                surname: paramSurname);
        }

        /// <summary>
        /// Tests that a empty first name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyFirstNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramSurname = "Wright";

            // ACT
            _ = new Host(
                id: paramId,
                firstName: string.Empty,
                surname: paramSurname);
        }

        /// <summary>
        /// Tests that a long first name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongFirstNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            string paramFirstName = new string('x', 100);
            const string paramSurname = "Wright";

            // ACT
            _ = new Host(
                id: paramId,
                firstName: paramFirstName,
                surname: paramSurname);
        }

        #endregion Property: FirstName

        #region Property: Surname

        /// <summary>
        /// Tests that a null surname throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullSurnameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramFirstName = "Steve";

            // ACT
            _ = new Host(
                id: paramId,
                firstName: paramFirstName,
                surname: null!);
        }

        /// <summary>
        /// Tests that a empty surname throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptySurnameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramFirstName = "Steve";

            // ACT
            _ = new Host(
                id: paramId,
                firstName: paramFirstName,
                surname: string.Empty);
        }

        /// <summary>
        /// Tests that a long surname throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongSurnameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramFirstName = "Steve";
            string paramSurname = new string('x', 100);

            // ACT
            _ = new Host(
                id: paramId,
                firstName: paramFirstName,
                surname: paramSurname);
        }

        #endregion Property: Surname
    }
}