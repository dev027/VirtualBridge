// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Domain.Exceptions;

namespace VirtualBridge.Domain.Tests.DomainObjects.Organisations.OrganisationTests
{
    /// <summary>
    /// Constructor tests for <see cref="IOrganisation"/>.
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
            const string paramShortName = "Bradgate";
            const string paramMediumName = "Bradgate BC";
            const string paramLongName = "Bradgate Bridge Club";
            const string paramCode = "BRADGATE";

            // ACT
            IOrganisation organisation = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: paramCode);

            // ASSERT
            Assert.IsNotNull(organisation);
            Assert.AreNotEqual(Guid.Empty, organisation.Id);
            Assert.AreEqual(paramId, organisation.Id);
            Assert.AreEqual(paramShortName, organisation.ShortName);
            Assert.AreEqual(paramMediumName, organisation.MediumName);
            Assert.AreEqual(paramLongName, organisation.LongName);
            Assert.AreEqual(paramCode, organisation.Code);
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
            const string paramShortName = "Bradgate";
            const string paramMediumName = "Bradgate BC";
            const string paramLongName = "Bradgate Bridge Club";
            const string paramCode = "BRADGATE";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: paramCode);
        }

        #endregion Property: Id

        #region Property: ShortName

        /// <summary>
        /// Tests that a null short name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullShortNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramMediumName = "Bradgate BC";
            const string paramLongName = "Bradgate Bridge Club";
            const string paramCode = "BRADGATE";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: null!,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: paramCode);
        }

        /// <summary>
        /// Tests that a empty short name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyShortNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramMediumName = "Bradgate BC";
            const string paramLongName = "Bradgate Bridge Club";
            const string paramCode = "BRADGATE";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: string.Empty,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: paramCode);
        }

        /// <summary>
        /// Tests that a long short name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongShortNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            string paramShortName = new string('x', 20);
            const string paramMediumName = "Bradgate BC";
            const string paramLongName = "Bradgate Bridge Club";
            const string paramCode = "BRADGATE";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: paramCode);
        }

        #endregion Property: ShortName

        #region Property: MediumName

        /// <summary>
        /// Tests that a null medium name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullMediumNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramShortName = "Bradgate";
            const string paramLongName = "Bradgate Bridge Club";
            const string paramCode = "BRADGATE";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: null!,
                longName: paramLongName,
                code: paramCode);
        }

        /// <summary>
        /// Tests that a empty medium name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyMediumNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramShortName = "Bradgate";
            const string paramLongName = "Bradgate Bridge Club";
            const string paramCode = "BRADGATE";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: string.Empty,
                longName: paramLongName,
                code: paramCode);
        }

        /// <summary>
        /// Tests that a long medium name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongMediumNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramShortName = "Bradgate";
            string paramMediumName = new string('x', 100);
            const string paramLongName = "Bradgate Bridge Club";
            const string paramCode = "BRADGATE";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: paramCode);
        }

        #endregion Property: MediumName

        #region Property: LongName

        /// <summary>
        /// Tests that a null long name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullLongNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramShortName = "Bradgate";
            const string paramMediumName = "Bradgate BC";
            const string paramCode = "BRADGATE";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: null!,
                code: paramCode);
        }

        /// <summary>
        /// Tests that a empty long name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyLongNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramShortName = "Bradgate";
            const string paramMediumName = "Bradgate BC";
            const string paramCode = "BRADGATE";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: string.Empty,
                code: paramCode);
        }

        /// <summary>
        /// Tests that a long long name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongLongNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramShortName = "Bradgate";
            const string paramMediumName = "Bradgate BC";
            string paramLongName = new string('x', 100);
            const string paramCode = "BRADGATE";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: paramCode);
        }

        #endregion Property: LongName

        #region Property: Code

        /// <summary>
        /// Tests that a null code throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullCodeThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramShortName = "Bradgate";
            const string paramMediumName = "Bradgate BC";
            const string paramLongName = "Bradgate Bridge Club";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: null!);
        }

        /// <summary>
        /// Tests that a empty code throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyCodeThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramShortName = "Bradgate";
            const string paramMediumName = "Bradgate BC";
            const string paramLongName = "Bradgate Bridge Club";

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: string.Empty);
        }

        /// <summary>
        /// Tests that a long code throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongCodeThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramShortName = "Bradgate";
            const string paramMediumName = "Bradgate BC";
            const string paramLongName = "Bradgate Bridge Club";
            string paramCode = new string('x', 20);

            // ACT
            _ = new Organisation(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: paramCode);
        }

        #endregion Property: Code
    }
}