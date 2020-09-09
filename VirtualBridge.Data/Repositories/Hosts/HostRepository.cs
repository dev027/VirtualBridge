// <copyright file="HostRepository.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VirtualBridge.Data.DbContexts;
using VirtualBridge.Data.Dtos;
using VirtualBridge.Data.Utilities;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.DomainObjects.Hosts;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Data.Repositories.Hosts
{
    /// <summary>
    /// Audit Header Repository.
    /// </summary>
    public class HostRepository : RepositoryBase, IHostRepository
    {
        private readonly DataContext context;
        private readonly ILogger<HostRepository> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HostRepository"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="dataContext">Data context.</param>
        public HostRepository(
            ILogger<HostRepository> logger,
            DataContext dataContext)
            : base(nameof(HostRepository))
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.context = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        /// <inheritdoc/>
        public async Task CreateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            IHost host)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, organisation) {@Who} {@Organisation}",
                nameof(this.CreateAsync),
                who,
                host);

            HostDto dto = HostDto.ToDto(host);

            this.context.Hosts.Add(dto);
            await this.context.SaveChangesAsync().ConfigureAwait(false);
            Audit.AuditCreate(auditHeader, dto, dto.Id);

            this.logger.LogTrace(
                "EXIT {Method}(who) {@Who}",
                nameof(this.CreateAsync),
                who);
        }

        /// <inheritdoc/>
        public async Task<IList<IHost>> GetAllAsync(IWho who)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who) {@Who}",
                nameof(this.GetAllAsync),
                who);

            IList<HostDto> dtos = await this.context.Hosts
                .AsNoTracking()
                .TagWith(this.Tag(who, nameof(this.GetAllAsync)))
                .ToListAsync()
                .ConfigureAwait(false);

            IList<IHost> hosts = dtos.Select(h => h.ToDomain())
                .ToList();

            this.logger.LogTrace(
                "EXIT {Method}(who, organisations) {@Who} {@Organisations}",
                nameof(this.GetAllAsync),
                who,
                hosts);

            return hosts;
        }

        /// <inheritdoc/>
        public async Task<IHost> GetByIdAsync(IWho who, Guid hostId)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, organisationId) {@Who} {HostId}",
                nameof(this.GetByIdAsync),
                who,
                hostId);

            IHost host = (await this.context.Hosts
                    .AsNoTracking()
                    .TagWith(this.Tag(who, nameof(this.GetByIdAsync)))
                    .FirstOrDefaultAsync(h => h.Id == hostId)
                    .ConfigureAwait(false))
                .ToDomain();

            this.logger.LogTrace(
                "EXIT {Method}(who, organisation) {@Who} {@Host}",
                nameof(this.GetByIdAsync),
                who,
                host);

            return host;
        }

        /// <inheritdoc/>
        public async Task<bool> HaveAsync(IWho who)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who) {@Who}",
                nameof(this.HaveAsync),
                who);

            bool haveHostss = await this.context.Hosts
                .TagWith(this.Tag(who, nameof(this.HaveAsync)))
                .AnyAsync()
                .ConfigureAwait(false);

            this.logger.LogTrace(
                "EXIT {Method}(who, haveOrganisations) {@Who} {HaveHostss}",
                nameof(this.HaveAsync),
                who,
                haveHostss);

            return haveHostss;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            IHost host)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, host) {@Who} {@Host}",
                nameof(this.UpdateAsync),
                who,
                host);

            HostDto dto = HostDto.ToDto(host);
            HostDto original = await this.context.FindAsync<HostDto>(host.Id)
                .ConfigureAwait(false);
            Audit.AuditUpdate(auditHeader, dto.Id, original, dto);

            this.context.Entry(original).CurrentValues.SetValues(dto);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            this.logger.LogTrace(
                "EXIT {Method}(who) {@Who}",
                nameof(this.UpdateAsync),
                who);
        }
    }
}