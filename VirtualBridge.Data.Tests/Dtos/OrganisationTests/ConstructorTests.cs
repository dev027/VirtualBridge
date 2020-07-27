// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Dtos;

namespace VirtualBridge.Data.Tests.Dtos.OrganisationTests
{
    /// <summary>
    /// Test constructor for <see cref="OrganisationDto" />.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the default constructor.
        /// </summary>
        [TestMethod]
        public void Test_Default_Constructor()
        {
            // ACT
            OrganisationDto organisationDto = new OrganisationDto();

            // ASSERT
            Assert.AreEqual(Guid.Empty, organisationDto.Id);
            Assert.AreEqual(null, organisationDto.ShortName);
            Assert.AreEqual(null, organisationDto.MediumName);
            Assert.AreEqual(null, organisationDto.LongName);
            Assert.AreEqual(null, organisationDto.Code);
        }

        /// <summary>
        /// Tests the basic constructor.
        /// </summary>
        [TestMethod]
        public void Test_Basic_Constructor()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            const string paramShortName = "Short";
            const string paramMediumName = "Medium";
            const string paramLongName = "Long";
            const string paramCode = "Code";

            // ACT
            OrganisationDto dto = new OrganisationDto(
                id: paramId,
                shortName: paramShortName,
                mediumName: paramMediumName,
                longName: paramLongName,
                code: paramCode);

            // ASSERT
            Assert.AreEqual(paramId, dto.Id);
            Assert.AreEqual(paramShortName, dto.ShortName);
            Assert.AreEqual(paramMediumName, dto.MediumName);
            Assert.AreEqual(paramLongName, dto.LongName);
            Assert.AreEqual(paramCode, dto.Code);
        }
    }
}