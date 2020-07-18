// <copyright file="ShortName.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

namespace VirtualBridge.Domain.DomainObjects.Organisations.Metadata
{
    /// <summary>
    /// Metadata for <see cref="IOrganisation.ShortName"/>.
    /// </summary>
    public static class ShortName
    {
        /// <summary>
        /// The minimum length.
        /// </summary>
        public const int MinLength = 1;

        /// <summary>
        /// The maximum length.
        /// </summary>
        public const int MaxLength = 10;
    }
}