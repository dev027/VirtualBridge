// <copyright file="CompetitionRepository.cs" company="Do It Wright">
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
using VirtualBridge.Data.Repositories.Hosts;
using VirtualBridge.Data.Utilities;
using VirtualBridge.Domain.DomainObjects.AuditHeaders;
using VirtualBridge.Domain.DomainObjects.Competitions;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Data.Repositories.Competitions
{
    /// <summary>
    /// Audit Header Repository.
    /// </summary>
    public class CompetitionRepository : RepositoryBase, ICompetitionRepository
    {
        private readonly DataContext context;
        private readonly ILogger<HostRepository> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitionRepository"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="dataContext">Data context.</param>
        public CompetitionRepository(
            ILogger<HostRepository> logger,
            DataContext dataContext)
            : base(nameof(CompetitionRepository))
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.context = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        /// <inheritdoc/>
        public async Task CreateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            ICompetition competition)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, organisation) {@Who} {@Competition}",
                nameof(this.CreateAsync),
                who,
                competition);

            CompetitionDto dto = CompetitionDto.ToDto(competition);

            this.context.Competitions.Add(dto);
            await this.context.SaveChangesAsync().ConfigureAwait(false);
            Audit.AuditCreate(auditHeader, dto, dto.Id);

            this.logger.LogTrace(
                "EXIT {Method}(who) {@Who}",
                nameof(this.CreateAsync),
                who);
        }

        /// <inheritdoc/>
        public async Task<IList<ICompetition>> GetAllAsync(IWho who)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who) {@Who}",
                nameof(this.GetAllAsync),
                who);

            IList<CompetitionDto> dtos = await this.context.Competitions
                .AsNoTracking()
                .TagWith(this.Tag(who, nameof(this.GetAllAsync)))
                .ToListAsync()
                .ConfigureAwait(false);

            IList<ICompetition> competitions = dtos.Select(c => c.ToDomain())
                .ToList();

            this.logger.LogTrace(
                "EXIT {Method}(who, organisations) {@Who} {@Competitions}",
                nameof(this.GetAllAsync),
                who,
                competitions);

            return competitions;
        }

        /// <inheritdoc/>
        public async Task<ICompetition> GetByIdAsync(IWho who, Guid competitionId)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, organisationId) {@Who} {CompetitionId}",
                nameof(this.GetByIdAsync),
                who,
                competitionId);

            ICompetition competition = (await this.context.Competitions
                    .AsNoTracking()
                    .TagWith(this.Tag(who, nameof(this.GetByIdAsync)))
                    .FirstOrDefaultAsync(c => c.Id == competitionId)
                    .ConfigureAwait(false))
                .ToDomain();

            this.logger.LogTrace(
                "EXIT {Method}(who, organisation) {@Who} {@Competition}",
                nameof(this.GetByIdAsync),
                who,
                competition);

            return competition;
        }

        /// <inheritdoc/>
        public async Task<bool> HaveAsync(IWho who)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who) {@Who}",
                nameof(this.HaveAsync),
                who);

            bool haveCompetitions = await this.context.Competitions
                .TagWith(this.Tag(who, nameof(this.HaveAsync)))
                .AnyAsync()
                .ConfigureAwait(false);

            this.logger.LogTrace(
                "EXIT {Method}(who, haveOrganisations) {@Who} {HaveCompetitions}",
                nameof(this.HaveAsync),
                who,
                haveCompetitions);

            return haveCompetitions;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(
            IWho who,
            IAuditHeaderWithAuditDetails auditHeader,
            ICompetition competition)
        {
            this.logger.LogTrace(
                "ENTRY {Method}(who, host) {@Who} {@Competition}",
                nameof(this.UpdateAsync),
                who,
                competition);

            CompetitionDto dto = CompetitionDto.ToDto(competition);
            CompetitionDto original = await this.context.FindAsync<CompetitionDto>(competition.Id)
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