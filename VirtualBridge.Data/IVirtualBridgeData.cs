// <copyright file="IVirtualBridgeData.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using VirtualBridge.Data.Repositories.AuditHeaders;
using VirtualBridge.Data.Repositories.Organisations;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Data
{
    /// <summary>
    /// Data Access Layer - Transactions.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IVirtualBridgeData
    {
        /// <summary>
        /// Gets the Audit Header Repository.
        /// </summary>
        IAuditHeaderRepository AuditHeader { get; }

        /// <summary>
        /// Gets the Organisation Repository.
        /// </summary>
        IOrganisationRepository Organisation { get; }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="auditEvent">Audit Event.</param>
        /// <returns>Audit Header.</returns>
        public Task<IAuditHeaderWithAuditDetails> BeginTransactionAsync(
            IWho who,
            EAuditEvent auditEvent);

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        /// <param name="who">Who details.</param>
        /// <param name="auditHeader">Audit Header.</param>
        /// <returns>Nothing.</returns>
        public Task CommitTransactionAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader);

        /// <summary>
        /// Rollbacks the Transaction.
        /// </summary>
        /// <param name="who">Who details.</param>
        public void RollbackTransaction(IWho who);
    }
}