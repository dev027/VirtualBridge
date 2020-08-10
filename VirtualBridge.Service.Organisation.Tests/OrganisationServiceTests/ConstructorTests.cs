// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VirtualBridge.Data;
using MockFactory = VirtualBridge.Service.Organisation.Tests.TestUtilities.MockFactory;

namespace VirtualBridge.Service.Organisation.Tests.OrganisationServiceTests
{
    /// <summary>
    /// Constructor tests for <see cref="OrganisationService"/>.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests with valid values.
        /// </summary>
        [TestMethod]
        public void Test_With_Valid_Values()
        {
            // ARRANGE
            IMock<ILogger<IOrganisationService>> loggerMock =
                MockFactory.CreateLoggerMock<IOrganisationService>();

            IMock<IVirtualBridgeData> dataMock = new Mock<IVirtualBridgeData>(MockBehavior.Strict);

            // ACT
            _ = new OrganisationService(
                logger: loggerMock.Object,
                data: dataMock.Object);

            // ASSERT
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests that  null logger throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Null_Logger_Throws_Exception()
        {
            // ARRANGE
            IMock<IVirtualBridgeData> dataMock = new Mock<IVirtualBridgeData>(MockBehavior.Strict);

            // ACT
            _ = new OrganisationService(
                logger: null!,
                data: dataMock.Object);
        }

        /// <summary>
        /// Tests that  null virtual bridge data throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Null_VirtualBridgeData_Throws_Exception()
        {
            // ARRANGE
            IMock<ILogger<IOrganisationService>> loggerMock =
                MockFactory.CreateLoggerMock<IOrganisationService>();

            // ACT
            _ = new OrganisationService(
                logger: loggerMock.Object,
                data: null!);
        }
    }
}