// <copyright file="TestConstructor.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VirtualBridge.Data.DbContexts;
using VirtualBridge.Data.Repositories.AuditHeaders;
using VirtualBridge.Data.Repositories.Organisations;
using VirtualBridge.Data.Tests.TestUtilities;

namespace VirtualBridge.Data.Tests.VirtualBridgeDataTests
{
    /// <summary>
    /// Test the constructor for <see cref="VirtualBridgeData"/>.
    /// </summary>
    [TestClass]
    public class TestConstructor
    {
        /// <summary>
        /// Tests the with valid values.
        /// </summary>
        /// <returns>Nothing.</returns>
        [TestMethod]
        public async Task Test_With_Valid_Values()
        {
            // ARRANGE
            Mock<ILogger<VirtualBridgeData>> loggerMock =
                TestUtilities.MockFactory.CreateLoggerMock<VirtualBridgeData>();
            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<TestConstructor>(nameof(this.Test_With_Valid_Values));
            await using DataContext dataContext = new DataContext(dbOptions);

            Mock<IAuditHeaderRepository> auditHeaderRepositoryMock =
                new Mock<IAuditHeaderRepository>();
            Mock<IOrganisationRepository> organisationRepositoryMock =
                new Mock<IOrganisationRepository>();

            // ACT
            IVirtualBridgeData virtualBridgeData = new VirtualBridgeData(
                logger: loggerMock.Object,
                dataContext: dataContext,
                auditHeaderRepository: auditHeaderRepositoryMock.Object,
                organisationRepository: organisationRepositoryMock.Object);

            // ASSERT
            Assert.IsNotNull(virtualBridgeData.AuditHeader);
            Assert.IsNotNull(virtualBridgeData.Organisation);
        }

        /// <summary>
        /// Tests the that null logger throws exception.
        /// </summary>
        /// <returns>Nothing.</returns>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Test_That_Null_Logger_Throws_Exception()
        {
            // ARRANGE
            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<TestConstructor>(nameof(this.Test_With_Valid_Values));
            await using DataContext dataContext = new DataContext(dbOptions);

            Mock<IAuditHeaderRepository> auditHeaderRepositoryMock =
                new Mock<IAuditHeaderRepository>();
            Mock<IOrganisationRepository> organisationRepositoryMock =
                new Mock<IOrganisationRepository>();

            // ACT
            _ = new VirtualBridgeData(
                logger: null!,
                dataContext: dataContext,
                auditHeaderRepository: auditHeaderRepositoryMock.Object,
                organisationRepository: organisationRepositoryMock.Object);
        }

        /// <summary>
        /// Tests the that null context throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_That_Null_Context_Throws_Exception()
        {
            // ARRANGE
            Mock<ILogger<VirtualBridgeData>> loggerMock =
                TestUtilities.MockFactory.CreateLoggerMock<VirtualBridgeData>();

            Mock<IAuditHeaderRepository> auditHeaderRepositoryMock =
                new Mock<IAuditHeaderRepository>();
            Mock<IOrganisationRepository> organisationRepositoryMock =
                new Mock<IOrganisationRepository>();

            // ACT
            _ = new VirtualBridgeData(
                logger: loggerMock.Object,
                dataContext: null!,
                auditHeaderRepository: auditHeaderRepositoryMock.Object,
                organisationRepository: organisationRepositoryMock.Object);
        }

        /// <summary>
        /// Tests the that null audit header repository throws exception.
        /// </summary>
        /// <returns>Nothing.</returns>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Test_That_Null_Audit_Header_Repository_Throws_Exception()
        {
            // ARRANGE
            Mock<ILogger<VirtualBridgeData>> loggerMock =
                TestUtilities.MockFactory.CreateLoggerMock<VirtualBridgeData>();
            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<TestConstructor>(nameof(this.Test_With_Valid_Values));
            await using DataContext dataContext = new DataContext(dbOptions);

            Mock<IOrganisationRepository> organisationRepositoryMock =
                new Mock<IOrganisationRepository>();

            // ACT
            _ = new VirtualBridgeData(
                logger: loggerMock.Object,
                dataContext: dataContext,
                auditHeaderRepository: null!,
                organisationRepository: organisationRepositoryMock.Object);
        }

        /// <summary>
        /// Tests the that null organisation repository throws exception.
        /// </summary>
        /// <returns>Nothing.</returns>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Test_That_Null_Organisation_Repository_Throws_Exception()
        {
            // ARRANGE
            Mock<ILogger<VirtualBridgeData>> loggerMock =
                TestUtilities.MockFactory.CreateLoggerMock<VirtualBridgeData>();
            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<TestConstructor>(nameof(this.Test_With_Valid_Values));
            await using DataContext dataContext = new DataContext(dbOptions);

            Mock<IAuditHeaderRepository> auditHeaderRepositoryMock =
                new Mock<IAuditHeaderRepository>();

            // ACT
            _ = new VirtualBridgeData(
                logger: loggerMock.Object,
                dataContext: dataContext,
                auditHeaderRepository: auditHeaderRepositoryMock.Object,
                organisationRepository: null!);
        }
    }
}