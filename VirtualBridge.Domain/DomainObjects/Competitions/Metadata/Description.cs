// <copyright file="Description.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

namespace VirtualBridge.Domain.DomainObjects.Competitions.Metadata
{
    /// <summary>
    /// Metadata for <see cref="ICompetition.Description"/>.
    /// </summary>
    public static class Description
    {
        /// <summary>
        /// The minimum length.
        /// </summary>
        public const int MinLength = 1;

        /// <summary>
        /// The maximum length.
        /// </summary>
        public const int MaxLength = 50;
    }
}