// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Domain.DomainObjects.RegularCompetitions;
using VirtualBridge.Domain.Exceptions;

namespace VirtualBridge.Domain.Tests.DomainObjects.RegularCompetitions.RegularCompetitionTests
{
    /// <summary>
    /// Constructor tests for <see cref="IRegularCompetition"/>.
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
            IRegularCompetition competition = new RegularCompetition(
                id: paramId,
                name: paramName,
                description: paramDescription,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);

            // ASSERT
            Assert.IsNotNull(competition);
            Assert.AreNotEqual(Guid.Empty, competition.Id);
            Assert.AreEqual(paramId, competition.Id);
            Assert.AreEqual(paramName, competition.Name);
            Assert.AreSame(paramOrganisation, competition.Organisation);
            Assert.AreEqual(paramDayOfWeek, competition.DayOfWeek);
            Assert.AreEqual(paramTimeOfDay, competition.TimeOfDay);
        }

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
            _ = new RegularCompetition(
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
            _ = new RegularCompetition(
                id: paramId,
                name: paramName,
                description: paramDescription,
                organisation: paramOrganisation,
                dayOfWeek: paramDayOfWeek,
                timeOfDay: paramTimeOfDay,
                timePeriod: paramTimePeriod);
        }

        #endregion
    }
}