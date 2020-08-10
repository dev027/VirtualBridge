// <copyright file="VirtualBridgeService.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VirtualBridge.Data;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Service.Helpers;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Service
{
    /// <summary>
    /// Service Layer for Virtual Bridge.
    /// </summary>
    public class VirtualBridgeService : IVirtualBridgeService
    {
        #region Private Members

        private readonly ILogger<VirtualBridgeService> logger;
        private readonly IVirtualBridgeData data;

        #endregion Private Members

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VirtualBridgeService" /> class.</summary>
        /// <param name="logger">The logger.</param>
        /// <param name="data">The data.</param>
        public VirtualBridgeService(
            ILogger<VirtualBridgeService> logger,
            IVirtualBridgeData data)
        {
            this.logger = logger;
            this.data = data;
        }

        #endregion Constructors

        #region Organisation

        #region Create

        /// <inheritdoc />
        public Task CreateOrganisationAsync(
            IWho who,
            EAuditEvent auditEvent,
            IOrganisation organisation)
        {
            return OrganisationHelper.CreateOrganisationAsync(
                logger: this.logger,
                data: this.data,
                who: who,
                auditEvent: auditEvent,
                organisation: organisation);
        }

        #endregion

        #endregion


    }
}