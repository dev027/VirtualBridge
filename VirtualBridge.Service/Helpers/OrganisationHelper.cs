// <copyright file="OrganisationHelper.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VirtualBridge.Data;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Service.Helpers
{
    /// <summary>
    /// Service layer routines for Organisations.
    /// </summary>
    internal static class OrganisationHelper
    {
        /// <summary>
        /// Creates the organisation asynchronous.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="data">Data Layer.</param>
        /// <param name="who">Who details.</param>
        /// <param name="auditEvent">Audit event.</param>
        /// <param name="organisation">Organisation to create.</param>
        /// <returns>NOTHING.</returns>
        internal static async Task CreateOrganisationAsync(
            ILogger<VirtualBridgeService> logger,
            IVirtualBridgeData data,
            IWho who,
            EAuditEvent auditEvent,
            IOrganisation organisation)
        {
            logger.LogTrace(
                "ENTRY {Method}(who, organisation) {@who} {@organisation}",
                nameof(CreateOrganisationAsync),
                who,
                organisation);

            try
            {
                IAuditHeaderWithAuditDetails auditHeader =
                    await data.BeginTransactionAsync(who, auditEvent)
                        .ConfigureAwait(false);

                await data.Organisation.CreateAsync(
                        who: who,
                        auditHeader: auditHeader,
                        organisation: organisation)
                    .ConfigureAwait(false);

                await data.CommitTransactionAsync(who, auditHeader)
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                data.RollbackTransaction(who);
                throw;
            }

            logger.LogTrace(
                "EXIT {Method}(who) {@who}",
                nameof(CreateOrganisationAsync),
                who);
        }
    }
}