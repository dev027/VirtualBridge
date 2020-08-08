// <copyright file="TestBeginRollback.cs" company="Do It Wright">
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
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Utilities.Models.Whos;
using MockFactory = VirtualBridge.Data.Tests.TestUtilities.MockFactory;

namespace VirtualBridge.Data.Tests.VirtualBridgeDataTests
{
    /// <summary>
    /// Test <see cref="VirtualBridgeData.BeginTransactionAsync"/>
    /// and <see cref="VirtualBridgeData.RollbackTransaction"/>.
    /// </summary>
    [TestClass]
    public class TestBeginRollback
    {
        /// <summary>
        /// Tests that the rollback does not throw excetion.
        /// </summary>
        /// <returns>NOTHING.</returns>
        [TestMethod]
        public async Task Test_Rollback_Does_Not_Thorw_Exception()
        {
            // ARRANGE
            Mock<ILogger<VirtualBridgeData>> loggerMock =
                MockFactory.CreateLoggerMock<VirtualBridgeData>();
            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<TestBeginCommit>(
                    nameof(this.Test_Rollback_Does_Not_Thorw_Exception));
            await using DataContext dataContext = new DataContext(dbOptions);
            Mock<IAuditHeaderRepository> auditHeaderRepositoryMock
                = MockFactory.CreateRepositoryMock<IAuditHeaderRepository>();
            Mock<IOrganisationRepository> organisationRepositoryMock
                = MockFactory.CreateRepositoryMock<IOrganisationRepository>();

            VirtualBridgeData data = new VirtualBridgeData(
                logger: loggerMock.Object,
                dataContext: dataContext,
                auditHeaderRepository: auditHeaderRepositoryMock.Object,
                organisationRepository: organisationRepositoryMock.Object);

            IWho who = Create.Who();

            // ACT
            IAuditHeaderWithAuditDetails auditHeader = await data.BeginTransactionAsync(
                who: who,
                auditEvent: EAuditEvent.OrganisationMaintenance)
                .ConfigureAwait(false);

            data.RollbackTransaction(who);

            await data.CommitTransactionAsync(who, auditHeader)
                .ConfigureAwait(false);

            // ASSERT
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests the begin with null who throws exception.
        /// </summary>
        /// <returns>NOTHING.</returns>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Test_Rollback_With_Null_Who_Throws_Exception()
        {
            // ARRANGE
            Mock<ILogger<VirtualBridgeData>> loggerMock =
                MockFactory.CreateLoggerMock<VirtualBridgeData>();
            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<TestBeginCommit>(
                    nameof(this.Test_Rollback_Does_Not_Thorw_Exception));
            await using DataContext dataContext = new DataContext(dbOptions);
            Mock<IAuditHeaderRepository> auditHeaderRepositoryMock =
                MockFactory.CreateRepositoryMock<IAuditHeaderRepository>();
            Mock<IOrganisationRepository> organisationRepositoryMock =
                MockFactory.CreateRepositoryMock<IOrganisationRepository>();

            VirtualBridgeData data = new VirtualBridgeData(
                logger: loggerMock.Object,
                dataContext: dataContext,
                auditHeaderRepository: auditHeaderRepositoryMock.Object,
                organisationRepository: organisationRepositoryMock.Object);

            // ACT
            data.RollbackTransaction(
                who: null!);
        }
    }
}
