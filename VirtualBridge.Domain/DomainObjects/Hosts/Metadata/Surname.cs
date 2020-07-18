// <copyright file="Surname.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

namespace VirtualBridge.Domain.DomainObjects.Hosts.Metadata
{
    /// <summary>
    /// Metadata for <see cref="IHost.Surname"/>.
    /// </summary>
    public static class Surname
    {
        /// <summary>
        /// The minimum length.
        /// </summary>
        public const int MinLength = 1;

        /// <summary>
        /// The maximum length.
        /// </summary>
        public const int MaxLength = 20;
    }
}