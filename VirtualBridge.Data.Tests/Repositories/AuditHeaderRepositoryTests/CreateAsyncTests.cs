// <copyright file="CreateAsyncTests.cs" company="Do It Wright">
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
using VirtualBridge.Data.Tests.TestUtilities;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditDetails;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Data.Tests.Repositories.AuditHeaderRepositoryTests
{
    /// <summary>
    /// Test <see cref="IAuditHeaderRepository.CreateAsync"/>.
    /// </summary>
    [TestClass]
    public class CreateAsyncTests
    {
        /// <summary>
        /// Tests with valid values.
        /// </summary>
        /// <returns>Nothing.</returns>
        [TestMethod]
        public async Task Test_With_Valid_Values()
        {
            // ARRANGE
            Mock<ILogger<AuditHeaderRepository>> loggerMock =
                TestUtilities.MockFactory.CreateLoggerMock<AuditHeaderRepository>();
            DbContextOptions<DataContext> dbOptions =
                TestUtils.DbContextOptionsInMemory<CreateAsyncTests>(nameof(this.Test_With_Valid_Values));
            await using DataContext dataContext = new DataContext(dbOptions);

            IAuditHeaderRepository repository = new AuditHeaderRepository(
                loggerMock.Object,
                dataContext);

            IAuditHeaderWithAuditDetails auditHeader = new AuditHeaderWithAuditDetails(
                auditEvent: EAuditEvent.OrganisationMaintenance,
                username: "Steve.Wright",
                correlationId: Guid.NewGuid());
            IAuditDetail auditDetail = AuditDetail.CreateForUpdate(
                auditHeader: auditHeader,
                tableName: "TableName",
                columnName: "ColumnName",
                recordId: Guid.NewGuid(),
                oldValue: "Old Value",
                newValue: "New Value");
            auditHeader.AuditDetails.Add(auditDetail);

            IWho who = new Who(
                "TestController",
                "Action",
                "/TestController/Action",
                string.Empty);

            // ACT
            await repository.CreateAsync(who, auditHeader)
                .ConfigureAwait(false);

            // ASSERT
            Assert.AreEqual(1, await dataContext.AuditHeaders.CountAsync().ConfigureAwait(false));
            Assert.AreEqual(1, await dataContext.AuditDetails.CountAsync().ConfigureAwait(false));
        }
    }
}