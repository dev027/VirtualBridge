// <copyright file="MockFactory.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.Extensions.Logging;
using Moq;
using VirtualBridge.Data;
using VirtualBridge.Data.DbContexts;
using VirtualBridge.Data.Repositories.AuditHeaders;
using VirtualBridge.Data.Repositories.Organisations;

namespace VirtualBridge.Service.Organisation.Tests.TestUtilities
{
    /// <summary>
    /// Mock Factory.
    /// </summary>
    internal static class MockFactory
    {
        /// <summary>
        /// Creates mock for <see cref="ILogger"/>.
        /// </summary>
        /// <typeparam name="T">Type of the class being logged.</typeparam>
        /// <returns>Logger Mock.</returns>
        internal static Mock<ILogger<T>> CreateLoggerMock<T>()
            => new Mock<ILogger<T>>(MockBehavior.Loose);

        /// <summary>
        /// Creates the repository mock.
        /// </summary>
        /// <typeparam name="T">Repository interface.</typeparam>
        /// <returns>Repository mock.</returns>
        internal static Mock<T> CreateRepositoryMock<T>()
            where T : class
        {
            return new Mock<T>(MockBehavior.Strict);
        }

        /// <summary>
        /// Creates a data layer.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="auditHeaderRepository">The audit header repository.</param>
        /// <param name="organisationRepository">The organisation repository.</param>
        /// <returns>Data layer.</returns>
        internal static IVirtualBridgeData CreateVirtualBridgeData(
            DataContext dataContext,
            IAuditHeaderRepository auditHeaderRepository = null,
            IOrganisationRepository organisationRepository = null)
        {
            Mock<ILogger<VirtualBridgeData>> loggerMock =
                MockFactory.CreateLoggerMock<VirtualBridgeData>();

            if (auditHeaderRepository == null)
            {
                Mock<IAuditHeaderRepository> auditHeaderRepositoryMock =
                    MockFactory.CreateRepositoryMock<IAuditHeaderRepository>();
                auditHeaderRepository = auditHeaderRepositoryMock.Object;
            }

            if (organisationRepository == null)
            {
                Mock<IOrganisationRepository> organisationRepositoryMock =
                    MockFactory.CreateRepositoryMock<IOrganisationRepository>();
                organisationRepository = organisationRepositoryMock.Object;
            }

            return new VirtualBridgeData(
                logger: loggerMock.Object,
                dataContext: dataContext,
                auditHeaderRepository: auditHeaderRepository,
                organisationRepository: organisationRepository);
        }
    }
}