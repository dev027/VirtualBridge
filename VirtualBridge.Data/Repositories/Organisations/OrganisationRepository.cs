// <copyright file="OrganisationRepository.cs" company="Do It Wright">
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
using VirtualBridge.Domain.DomainObjects.Organisations;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Data.Repositories.Organisations
{
    /// <summary>
    /// Audit Header Repository.
    /// </summary>
    public class OrganisationRepository : RepositoryBase, IOrganisationRepository
    {
        private readonly DataContext context;
        private readonly ILogger<OrganisationRepository> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganisationRepository"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="dataContext">Data context.</param>
        public OrganisationRepository(
            ILogger<OrganisationRepository> logger,
            DataContext dataContext)
            : base(nameof(OrganisationRepository))
        {
            this.logger = logger;
            this.context = dataContext;
        }

        /// <inheritdoc/>
        public async Task CreateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            IOrganisation organisation)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, organisation) {@who} {@organisation}",
                nameof(this.CreateAsync),
                who,
                organisation);

            OrganisationDto dto = OrganisationDto.ToDto(organisation);

            this.context.Organisations.Add(dto);
            await this.context.SaveChangesAsync().ConfigureAwait(false);
            Audit.AuditCreate(auditHeader, dto, dto.Id);

            this.logger.LogTrace(
                "EXIT {Method}(who) {@who}",
                nameof(this.CreateAsync),
                who);
        }

        /// <inheritdoc/>
        public async Task<IList<IOrganisation>> GetAllAsync(IWho who)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who) {@who}",
                nameof(this.GetAllAsync),
                who);

            IList<OrganisationDto> dtos = await this.context.Organisations
                .AsNoTracking()
                .TagWith(this.Tag(who, nameof(this.GetAllAsync)))
                .ToListAsync()
                .ConfigureAwait(false);

            IList<IOrganisation> organisations = dtos.Select(o => o.ToDomain())
                .ToList();

            this.logger.LogTrace(
                "EXIT {Method}(who, organisations) {@who} {@organisations}",
                nameof(this.GetAllAsync),
                who,
                organisations);

            return organisations;
        }

        /// <inheritdoc/>
        public async Task<IOrganisation> GetByIdAsync(IWho who, Guid organisationId)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, organisationId) {@who} {organisationId}",
                nameof(this.GetByIdAsync),
                who,
                organisationId);

            IOrganisation organisation = (await this.context.Organisations
                    .AsNoTracking()
                    .TagWith(this.Tag(who, nameof(this.GetByIdAsync)))
                    .FirstOrDefaultAsync(o => o.Id == organisationId)
                    .ConfigureAwait(false))
                .ToDomain();

            this.logger.LogTrace(
                "EXIT {Method}(who, organisation) {@who} {@organisation}",
                nameof(this.GetByIdAsync),
                who,
                organisation);

            return organisation;
        }

        /// <inheritdoc/>
        public async Task<bool> HaveAsync(IWho who)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who) {@who}",
                nameof(this.HaveAsync),
                who);

            bool haveOrganisations = await this.context.Organisations
                .TagWith(this.Tag(who, nameof(this.HaveAsync)))
                .AnyAsync()
                .ConfigureAwait(false);

            this.logger.LogTrace(
                "EXIT {Method}(who, haveOrganisations) {@who} {haveOrganisations}",
                nameof(this.HaveAsync),
                who,
                haveOrganisations);

            return haveOrganisations;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            IOrganisation organisation)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, organisation) {@who} {@organisation}",
                nameof(this.UpdateAsync),
                who,
                organisation);

            OrganisationDto dto = OrganisationDto.ToDto(organisation);
            OrganisationDto original = await this.context.FindAsync<OrganisationDto>(organisation.Id)
                .ConfigureAwait(false);
            Audit.AuditUpdate(auditHeader, dto.Id, original, dto);

            this.context.Entry(original).CurrentValues.SetValues(dto);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            this.logger.LogTrace(
                "EXIT {Method}(who) {@who}",
                nameof(this.UpdateAsync),
                who);
        }
    }
}