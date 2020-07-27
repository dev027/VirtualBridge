// <copyright file="ToDomainTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Domain.DomainObjects.Organisations;

namespace VirtualBridge.Data.Tests.Dtos.OrganisationTests
{
    /// <summary>
    /// Test <see cref="OrganisationDto.ToDomain"/>.
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
            OrganisationDto organisationDto = new OrganisationDto(
                id: Guid.NewGuid(),
                shortName: "Short",
                mediumName: "Medium",
                longName: "Long",
                code: "Code");

            // ACT
            IOrganisation organisation = organisationDto.ToDomain();

            // ASSERT
            Assert.IsNotNull(organisation);
            Assert.AreEqual(organisationDto.Id, organisation.Id);
            Assert.AreEqual(organisationDto.ShortName, organisation.ShortName);
            Assert.AreEqual(organisationDto.MediumName, organisation.MediumName);
            Assert.AreEqual(organisationDto.LongName, organisation.LongName);
            Assert.AreEqual(organisationDto.Code, organisation.Code);
        }
    }
}