// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.Competitions;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Domain.Exceptions;

namespace VirtualBridge.Domain.Tests.DomainObjects.Competitions.CompetitionTests
{
    /// <summary>
    /// Constructor tests for <see cref="ICompetition"/>.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
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
            const string paramName = "Saturday Pairs";
            const string paramDescription = "Fortnightly MP Pairs";
            IOrganisation paramOrganisation = new Organisation(
                id: Guid.NewGuid(),
                shortName: "LCBA",
                mediumName: "LCBA",
                longName: "Leicestershire Contract Bridge Association",
                code: "LCBA");
            const DayOfWeek paramDayOfWeek = DayOfWeek.Saturday;
            TimeSpan paramTimeOfDay = new TimeSpan(10, 0, 0);
            const ETimePeriod paramTimePeriod = ETimePeriod.Morning;

            // ACT
            _ = new Competition(
                id: paramId,
                name: paramName,
                description: paramDescription,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        #endregion Property: Id

        #region Property: Name

        /// <summary>
        /// Tests that a null name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramDescription = "Fortnightly MP Pairs";
            IOrganisation paramOrganisation = new Organisation(
                id: Guid.NewGuid(),
                shortName: "LCBA",
                mediumName: "LCBA",
                longName: "Leicestershire Contract Bridge Association",
                code: "LCBA");
            const DayOfWeek paramDayOfWeek = DayOfWeek.Saturday;
            TimeSpan paramTimeOfDay = new TimeSpan(10, 0, 0);
            const ETimePeriod paramTimePeriod = ETimePeriod.Morning;

            // ACT
            _ = new Competition(
                id: paramId,
                name: null!,
                description: paramDescription,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        /// <summary>
        /// Tests that a empty name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramDescription = "Fortnightly MP Pairs";
            IOrganisation paramOrganisation = new Organisation(
                id: Guid.NewGuid(),
                shortName: "LCBA",
                mediumName: "LCBA",
                longName: "Leicestershire Contract Bridge Association",
                code: "LCBA");
            const DayOfWeek paramDayOfWeek = DayOfWeek.Saturday;
            TimeSpan paramTimeOfDay = new TimeSpan(10, 0, 0);
            const ETimePeriod paramTimePeriod = ETimePeriod.Morning;

            // ACT
            _ = new Competition(
                id: paramId,
                name: string.Empty,
                description: paramDescription,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        /// <summary>
        /// Tests that a long name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongNameThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            string paramName = new string('x', 100);
            const string paramDescription = "Fortnightly MP Pairs";
            IOrganisation paramOrganisation = new Organisation(
                id: Guid.NewGuid(),
                shortName: "LCBA",
                mediumName: "LCBA",
                longName: "Leicestershire Contract Bridge Association",
                code: "LCBA");
            const DayOfWeek paramDayOfWeek = DayOfWeek.Saturday;
            TimeSpan paramTimeOfDay = new TimeSpan(10, 0, 0);
            const ETimePeriod paramTimePeriod = ETimePeriod.Morning;

            // ACT
            _ = new Competition(
                id: paramId,
                name: paramName,
                description: paramDescription,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        #endregion Property: Name

        #region Property: Description

        /// <summary>
        /// Tests that a null description throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullDescriptionThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramName = "Saturday Pairs";
            IOrganisation paramOrganisation = new Organisation(
                id: Guid.NewGuid(),
                shortName: "LCBA",
                mediumName: "LCBA",
                longName: "Leicestershire Contract Bridge Association",
                code: "LCBA");
            const DayOfWeek paramDayOfWeek = DayOfWeek.Saturday;
            TimeSpan paramTimeOfDay = new TimeSpan(10, 0, 0);
            const ETimePeriod paramTimePeriod = ETimePeriod.Morning;

            // ACT
            _ = new Competition(
                id: paramId,
                name: paramName,
                description: null!,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        /// <summary>
        /// Tests that a empty description throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestEmptyDescriptionThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramName = "Saturday Pairs";
            IOrganisation paramOrganisation = new Organisation(
                id: Guid.NewGuid(),
                shortName: "LCBA",
                mediumName: "LCBA",
                longName: "Leicestershire Contract Bridge Association",
                code: "LCBA");
            const DayOfWeek paramDayOfWeek = DayOfWeek.Saturday;
            TimeSpan paramTimeOfDay = new TimeSpan(10, 0, 0);
            const ETimePeriod paramTimePeriod = ETimePeriod.Morning;

            // ACT
            _ = new Competition(
                id: paramId,
                name: paramName,
                description: string.Empty,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        /// <summary>
        /// Tests that a long description throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestLongDescriptionThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramName = "Saturday Pairs";
            string paramDescription = new string('x', 100);
            IOrganisation paramOrganisation = new Organisation(
                id: Guid.NewGuid(),
                shortName: "LCBA",
                mediumName: "LCBA",
                longName: "Leicestershire Contract Bridge Association",
                code: "LCBA");
            const DayOfWeek paramDayOfWeek = DayOfWeek.Saturday;
            TimeSpan paramTimeOfDay = new TimeSpan(10, 0, 0);
            const ETimePeriod paramTimePeriod = ETimePeriod.Morning;

            // ACT
            _ = new Competition(
                id: paramId,
                name: paramName,
                description: paramDescription,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        #endregion Property: Description

        #region Property: TimeOfDay

        /// <summary>
        /// Tests that an invalid time of day throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestInvalidTimeOfDayThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramName = "Saturday Pairs";
            const string paramDescription = "Fortnightly MP Pairs";
            IOrganisation paramOrganisation = new Organisation(
                id: Guid.NewGuid(),
                shortName: "LCBA",
                mediumName: "LCBA",
                longName: "Leicestershire Contract Bridge Association",
                code: "LCBA");
            const DayOfWeek paramDayOfWeek = DayOfWeek.Saturday;
            TimeSpan paramTimeOfDay = new TimeSpan(1, 0, 0, 0);
            const ETimePeriod paramTimePeriod = ETimePeriod.Morning;

            // ACT
            _ = new Competition(
                id: paramId,
                name: paramName,
                description: paramDescription,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        #endregion Property: TimeOfDay

        #region Property: TimePeriod

        /// <summary>
        /// Tests that an invalid time period throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestInvalidTimePeriodThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramName = "Saturday Pairs";
            const string paramDescription = "Fortnightly MP Pairs";
            IOrganisation paramOrganisation = new Organisation(
                id: Guid.NewGuid(),
                shortName: "LCBA",
                mediumName: "LCBA",
                longName: "Leicestershire Contract Bridge Association",
                code: "LCBA");
            const DayOfWeek paramDayOfWeek = DayOfWeek.Saturday;
            TimeSpan paramTimeOfDay = new TimeSpan(10, 0, 0, 0);
            const ETimePeriod paramTimePeriod = ETimePeriod.Afternoon;

            // ACT
            _ = new Competition(
                id: paramId,
                name: paramName,
                description: paramDescription,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        #endregion

        #region Property: Organisation

        /// <summary>
        /// Tests that a null organisation throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ValidationResultException))]
        public void TestNullOrganisationThrowsException()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramName = "Saturday Pairs";
            const string paramDescription = "Fortnightly MP Pairs";
            const DayOfWeek paramDayOfWeek = DayOfWeek.Saturday;
            TimeSpan paramTimeOfDay = new TimeSpan(10, 0, 0);
            const ETimePeriod paramTimePeriod = ETimePeriod.Morning;

            // ACT
            _ = new Competition(
                id: paramId,
                name: paramName,
                description: paramDescription,
                organisation: null!,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        #endregion Property: Organisation
    }
}