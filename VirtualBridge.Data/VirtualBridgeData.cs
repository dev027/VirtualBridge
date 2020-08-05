// <copyright file="VirtualBridgeData.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VirtualBridge.Data.DbContexts;
using VirtualBridge.Data.Repositories.AuditHeaders;
using VirtualBridge.Data.Repositories.Organisations;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Data
{
    /// <summary>
    /// Data access layer.
    /// </summary>
    public class VirtualBridgeData : IVirtualBridgeData
    {
        private readonly DataContext context;
        private readonly ILogger<VirtualBridgeData> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualBridgeData"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="dataContext">Data Context.</param>
        /// <param name="auditHeaderRepository">Audit Header Repository.</param>
        /// <param name="organisationRepository">Organisation Repository.</param>
        public VirtualBridgeData(
            ILogger<VirtualBridgeData> logger,
            DataContext dataContext,
            IAuditHeaderRepository auditHeaderRepository,
            IOrganisationRepository organisationRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.context = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            this.AuditHeader = auditHeaderRepository ?? throw new ArgumentNullException(nameof(auditHeaderRepository));
            this.Organisation = organisationRepository ?? throw new ArgumentNullException(nameof(organisationRepository));
        }

        /// <inheritdoc />
        public IAuditHeaderRepository AuditHeader { get; }

        /// <inheritdoc />
        public IOrganisationRepository Organisation { get; }

        /// <inheritdoc />
        public Task<IAuditHeaderWithAuditDetails> BeginTransactionAsync(
            IWho who,
            EAuditEvent auditEvent)
        {
            if (who == null)
            {
                throw new ArgumentNullException(nameof(who));
            }

            return this.BeginTransactionInternalAsync(who, auditEvent);
        }

        /// <inheritdoc />
        public async Task CommitTransactionAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, auditHeader) {@Who} {@AuditHeader}",
                nameof(this.CommitTransactionAsync),
                who,
                auditHeader);

            if (auditHeader != null && auditHeader.AuditDetails.Any())
            {
                await this.AuditHeader.CreateAsync(who, auditHeader)
                    .ConfigureAwait(false);
            }

            this.context.Database.CommitTransaction();

            this.logger.LogTrace(
                "EXIT {Method}(who) {@Who}",
                nameof(this.CommitTransactionAsync),
                who);
        }

        /// <inheritdoc />
        public void RollbackTransaction(IWho who)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who) {@Who}",
                nameof(this.RollbackTransaction),
                who);

            this.context.Database.RollbackTransaction();

            this.logger.LogTrace(
                "EXIT {Method}(who) {@Who}",
                nameof(this.RollbackTransaction),
                who);
        }

        private async Task<IAuditHeaderWithAuditDetails> BeginTransactionInternalAsync(IWho who, EAuditEvent auditEvent)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, auditEvent) {@Who} {@AuditEvent}",
                nameof(this.BeginTransactionAsync),
                who,
                auditEvent);

            await this.context.Database.BeginTransactionAsync()
                .ConfigureAwait(false);

            AuditHeaderWithAuditDetails auditHeader = new AuditHeaderWithAuditDetails(
                auditEvent: auditEvent,
                username: "Guest",
                correlationId: who.CorrelationId);

            this.logger.LogTrace(
                "EXIT {Method}(who, auditHeader) {@Who} {@AuditHeader}",
                nameof(this.BeginTransactionAsync),
                who,
                auditHeader);

            return auditHeader;
        }
    }
}