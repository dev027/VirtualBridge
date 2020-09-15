// <copyright file="OrganisationService.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VirtualBridge.Data;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Service.Organisation
{
    /// <summary>
    /// Organisation Service Layer.
    /// </summary>
    /// <seealso cref="IOrganisationService" />
    public class OrganisationService : IOrganisationService
    {
        #region Private Members

        private readonly ILogger<IOrganisationService> logger;
        private readonly IVirtualBridgeData data;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganisationService"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="data">Data layer.</param>
        public OrganisationService(
            ILogger<IOrganisationService> logger,
            IVirtualBridgeData data)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }

        #endregion Constructors

        #region Public Methods

        /// <inheritdoc />
        public Task CreateAsync(
            IWho who,
            EAuditEvent auditEvent,
            IOrganisation organisation)
        {
            if (who == null)
            {
                throw new ArgumentNullException(nameof(who));
            }

            if (organisation == null)
            {
                throw new ArgumentNullException(nameof(organisation));
            }

            return CreateOrganisationInternalAsync();

            async Task CreateOrganisationInternalAsync()
            {
                this.logger.LogTrace(
                    "ENTRY {Method}(who, organisation) {@Who} {@Organisation}",
                    nameof(this.CreateAsync),
                    who,
                    organisation);

                try
                {
                    IAuditHeaderWithAuditDetails auditHeader = await this.data.BeginTransactionAsync(
                            who, auditEvent)
                        .ConfigureAwait(false);

                    await this.data.Organisation.CreateAsync(
                            who: who,
                            auditHeader: auditHeader,
                            organisation: organisation)
                        .ConfigureAwait(false);

                    await this.data.CommitTransactionAsync(who, auditHeader)
                        .ConfigureAwait(false);
                }
                catch (Exception)
                {
                    this.data.RollbackTransaction(who);
                    throw;
                }

                this.logger.LogTrace(
                    "EXIT {Method}(who) {@Who}",
                    nameof(this.CreateAsync),
                    who);
            }
        }

        /// <inheritdoc />
        public Task<IList<IOrganisation>> GetAllAsync(IWho who)
        {
            if (who == null)
            {
                throw new ArgumentNullException(nameof(who));
            }

            return GetAllAsyncInternal();

            async Task<IList<IOrganisation>> GetAllAsyncInternal()
            {
                this.logger.LogTrace(
                    "ENTRY {Method}(who, organisation) {@Who}",
                    nameof(this.GetAllAsync),
                    who);

                IList<IOrganisation> organisations = await this.data.Organisation.GetAllAsync(
                    who: who)
                    .ConfigureAwait(false);

                this.logger.LogTrace(
                    "EXIT {Method}(who, organisations) {@Who} {@Organisations}",
                    nameof(this.GetAllAsync),
                    who);

                return organisations;
            }
        }
    }

    #endregion Public Methods
}