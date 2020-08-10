// <copyright file="CreateAsyncTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VirtualBridge.Data;
using VirtualBridge.Data.DbContexts;
using VirtualBridge.Data.Repositories.Organisations;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Service.Organisation.Tests.TestUtilities;
using VirtualBridge.Utilities.Models.Whos;
using VirtualBridge.Utilities.Testing.Exceptions;
using MockFactory = VirtualBridge.Service.Organisation.Tests.TestUtilities.MockFactory;

namespace VirtualBridge.Service.Organisation.Tests.OrganisationServiceTests
{
    /// <summary>
    /// Tests for <see cref="IOrganisationService.CreateAsync"/>.
    /// </summary>
    [TestClass]
    public class CreateAsyncTests
    {
        /// <summary>
        /// Test by passing valid values.
        /// </summary>
        /// <returns>NOTHING.</returns>
        [TestMethod]
        public async Task Test_Passing_Valid_Values()
        {
            // ARRANGE
            IWho who = Create.Who();
            IOrganisation organisation = Create.Organisation();

            Mock<ILogger<IOrganisationService>> loggerMock =
                MockFactory.CreateLoggerMock<IOrganisationService>();

            Mock<IOrganisationRepository> organisationRepositoryMock =
                MockFactory.CreateRepositoryMock<IOrganisationRepository>();

            organisationRepositoryMock.Setup(x =>
                x.CreateAsync(
                    who,
                    It.IsAny<AuditHeaderWithAuditDetails>(),
                    organisation))
                    .Returns(Task.CompletedTask);

            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<CreateAsyncTests>(
                    nameof(this.Test_Passing_Valid_Values));
            await using DataContext dataContext = new DataContext(dbOptions);

            IVirtualBridgeData data =
                MockFactory.CreateVirtualBridgeData(
                    dataContext,
                    organisationRepository: organisationRepositoryMock.Object);

            IOrganisationService service = new OrganisationService(
                loggerMock.Object,
                data);

            // ACT
            await service.CreateAsync(
                    who: who,
                    auditEvent: EAuditEvent.OrganisationMaintenance,
                    organisation: organisation)
                .ConfigureAwait(false);

            // ASSERT
            organisationRepositoryMock.Verify(
                x => x.CreateAsync(
                    who,
                    It.IsAny<IAuditHeaderWithAuditDetails>(),
                    organisation),
                Times.Once);
        }

        /// <summary>
        /// Test passing null who throws exception.
        /// </summary>
        /// <returns>NOTHING.</returns>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Test_Passing_Null_Who_Throws_Exception()
        {
            // ARRANGE
            IOrganisation organisation = Create.Organisation();

            Mock<ILogger<IOrganisationService>> loggerMock =
                MockFactory.CreateLoggerMock<IOrganisationService>();

            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<CreateAsyncTests>(
                    nameof(this.Test_Passing_Valid_Values));
            await using DataContext dataContext = new DataContext(dbOptions);

            IVirtualBridgeData data =
                MockFactory.CreateVirtualBridgeData(
                    dataContext);

            IOrganisationService service = new OrganisationService(
                loggerMock.Object,
                data);

            // ACT
            await service.CreateAsync(
                    who: null!,
                    auditEvent: EAuditEvent.OrganisationMaintenance,
                    organisation: organisation)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Test passing null organisation throws exception.
        /// </summary>
        /// <returns>NOTHING.</returns>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Test_Passing_Null_Organisation_Throws_Exception()
        {
            // ARRANGE
            IWho who = Create.Who();

            Mock<ILogger<IOrganisationService>> loggerMock =
                MockFactory.CreateLoggerMock<IOrganisationService>();

            DbContextOptions<DataContext> dbOptions =
                 TestUtils.DbContextOptionsInMemory<CreateAsyncTests>(
                     nameof(this.Test_Passing_Valid_Values));
            await using DataContext dataContext = new DataContext(dbOptions);

            IVirtualBridgeData data =
                MockFactory.CreateVirtualBridgeData(
                    dataContext);

            IOrganisationService service = new OrganisationService(
                loggerMock.Object,
                data);

            // ACT
            await service.CreateAsync(
                    who: who,
                    auditEvent: EAuditEvent.OrganisationMaintenance,
                    organisation: null!)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Test exception triggers rollback.
        /// </summary>
        /// <returns>NOTHING.</returns>
        [TestMethod]
        [ExpectedException(typeof(DeliberateException))]
        public async Task Test_Exception_Triggers_Rollback()
        {
            // ARRANGE
            IWho who = Create.Who();
            IOrganisation organisation = Create.Organisation();

            Mock<ILogger<IOrganisationService>> loggerMock =
                MockFactory.CreateLoggerMock<IOrganisationService>();

            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<CreateAsyncTests>(
                    nameof(this.Test_Passing_Valid_Values));
            await using DataContext dataContext = new DataContext(dbOptions);

            Mock<IOrganisationRepository> organisationRepositoryMock =
                MockFactory.CreateRepositoryMock<IOrganisationRepository>();
            organisationRepositoryMock.Setup(x =>
                    x.CreateAsync(
                        It.IsAny<IWho>(),
                        It.IsAny<AuditHeaderWithAuditDetails>(),
                        It.IsAny<IOrganisation>()))
                .Throws<DeliberateException>();

            IVirtualBridgeData data =
                MockFactory.CreateVirtualBridgeData(
                    dataContext,
                    organisationRepository: organisationRepositoryMock.Object);

            IOrganisationService service = new OrganisationService(
                loggerMock.Object,
                data);

            // ACT
            await service.CreateAsync(
                    who: who,
                    auditEvent: EAuditEvent.OrganisationMaintenance,
                    organisation: organisation)
                .ConfigureAwait(false);
        }
    }
}