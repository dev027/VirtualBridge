﻿// <copyright file="IAuditHeaderWithAuditDetails.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Collections.Generic;
using VirtualBridge.Domain.DomainObjects.AuditDetails;

namespace VirtualBridge.Domain.DomainObjects.AuditHeaders
{
    /// <summary>
    /// Audit Header with Audit Details.
    /// </summary>
    /// <seealso cref="IAuditDetail" />
    public interface IAuditHeaderWithAuditDetails : IAuditHeader
    {
        /// <summary>
        /// Gets the Audit Details.
        /// </summary>
        IList<IAuditDetail> AuditDetails { get; }
    }
}