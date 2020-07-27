// <copyright file="ToDtoTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Domain.DomainObjects.Organisations;

namespace VirtualBridge.Data.Tests.Dtos.OrganisationTests
{
    /// <summary>
    /// Test <see cref="OrganisationDto.ToDto"/>.
    /// </summary>
    [TestClass]
    public class ToDtoTests
    {
        /// <summary>
        /// Tests method with valid values.
        /// </summary>
        [TestMethod]
        public void Test_Passing_Valid_Values()
        {
            // ARRANGE
            IOrganisation organisation = new Organisation(
                id: Guid.NewGuid(),
                shortName: "Short",
                mediumName: "Medium",
                longName: "Long",
                code: "Code");

            // ACT
            OrganisationDto organisationDto = OrganisationDto.ToDto(organisation);

            // ASSERT
            Assert.AreEqual(organisation.Id, organisationDto.Id);
            Assert.AreEqual(organisation.ShortName, organisationDto.ShortName);
            Assert.AreEqual(organisation.MediumName, organisationDto.MediumName);
            Assert.AreEqual(organisation.LongName, organisationDto.LongName);
            Assert.AreEqual(organisation.Code, organisationDto.Code);
        }

        /// <summary>
        /// Tests passing null Organisation throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Passing_Null_Organisation_Throws_Exception()
        {
            // ACT
            _ = OrganisationDto.ToDto(null!);
        }
    }
}