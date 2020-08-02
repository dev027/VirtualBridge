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
    public class VirtualBridgeData : IVirtualBridgeData, IDisposable
    {
        private readonly DataContext context;
        private readonly ILogger<VirtualBridgeData> logger;
        private bool disposedValue; // To detect redundant calls

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
            this.logger = logger;
            this.context = dataContext;
            this.AuditHeader = auditHeaderRepository;
            this.Organisation = organisationRepository;
        }

        /// <inheritdoc />
        public IAuditHeaderRepository AuditHeader { get; }

        /// <inheritdoc />
        public IOrganisationRepository Organisation { get;  }

        /// <inheritdoc />
        public async Task<IAuditHeaderWithAuditDetails> BeginTransactionAsync(
            IWho who,
            EAuditEvent auditEvent)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, auditEvent) {@Who} {@AuditEvent}",
                nameof(this.BeginTransactionAsync),
                who,
                auditEvent);

            if (who == null)
            {
                throw new ArgumentNullException(nameof(who));
            }

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

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                    this.context.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}