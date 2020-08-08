// <copyright file="TestBeginCommit.cs" company="Do It Wright">
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
using VirtualBridge.Domain.DomainObjects.AuditDetails;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Utilities.Models.Whos;
using MockFactory = VirtualBridge.Data.Tests.TestUtilities.MockFactory;

namespace VirtualBridge.Data.Tests.VirtualBridgeDataTests
{
    /// <summary>
    /// Test <see cref="VirtualBridgeData.BeginTransactionAsync"/>
    /// and <see cref="VirtualBridgeData.CommitTransactionAsync"/>.
    /// </summary>
    [TestClass]
    public class TestBeginCommit
    {
        /// <summary>
        /// Tests that the commit writes record.
        /// </summary>
        /// <returns>NOTHING.</returns>
        [TestMethod]
        public async Task Test_Commit_Writes_Record()
        {
            // ARRANGE
            Mock<ILogger<VirtualBridgeData>> loggerMock =
                MockFactory.CreateLoggerMock<VirtualBridgeData>();
            Mock<ILogger<AuditHeaderRepository>> auditHeaderRepositoryLoggerMock =
                MockFactory.CreateLoggerMock<AuditHeaderRepository>();
            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<TestBeginCommit>(
                    nameof(this.Test_Commit_Writes_Record));
            await using DataContext dataContext = new DataContext(dbOptions);
            AuditHeaderRepository auditHeaderRepository = new AuditHeaderRepository(
                logger: auditHeaderRepositoryLoggerMock.Object,
                dataContext: dataContext);
            Mock<IOrganisationRepository> organisationRepositoryMock
                = MockFactory.CreateRepositoryMock<IOrganisationRepository>();

            VirtualBridgeData data = new VirtualBridgeData(
                logger: loggerMock.Object,
                dataContext: dataContext,
                auditHeaderRepository: auditHeaderRepository,
                organisationRepository: organisationRepositoryMock.Object);

            IWho who = Create.Who();

            // ACT
            IAuditHeaderWithAuditDetails auditHeader = await data.BeginTransactionAsync(
                who: who,
                auditEvent: EAuditEvent.OrganisationMaintenance)
                .ConfigureAwait(false);

            auditHeader.AuditDetails.Add(
                AuditDetail.CreateForCreate(
                    auditHeader: auditHeader,
                    tableName: "Organisation",
                    columnName: "Name",
                    recordId: Guid.NewGuid(),
                    newValue: "NewValue"));

            await data.CommitTransactionAsync(who, auditHeader)
                .ConfigureAwait(false);

            // ASSERT
            int auditHeadersCount = await dataContext.AuditHeaders.CountAsync()
                .ConfigureAwait(false);
            int auditDetailsCount = await dataContext.AuditDetails.CountAsync()
                .ConfigureAwait(false);

            Assert.AreEqual(1, auditHeadersCount);
            Assert.AreEqual(1, auditDetailsCount);
        }

        /// <summary>
        /// Tests the begin with null who throws exception.
        /// </summary>
        /// <returns>NOTHING.</returns>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Test_Begin_With_Null_Who_Throws_Exception()
        {
            // ARRANGE
            Mock<ILogger<VirtualBridgeData>> loggerMock =
                MockFactory.CreateLoggerMock<VirtualBridgeData>();
            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<TestBeginCommit>(
                    nameof(this.Test_Begin_With_Null_Who_Throws_Exception));
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
            _ = data.BeginTransactionAsync(
                    who: null!,
                    auditEvent: EAuditEvent.OrganisationMaintenance)
                .ConfigureAwait(false);
        }
    }
}
