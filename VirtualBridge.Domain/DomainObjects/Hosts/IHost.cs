// <copyright file="IHost.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;

namespace VirtualBridge.Domain.DomainObjects.Hosts
{
    /// <summary>
    /// Virtual Bridge Club Host.
    /// </summary>
    public interface IHost
    {
        /// <summary>
        /// Gets the Host Id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the Host First Name.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets the Host Surname.
        /// </summary>
        public string Surname { get; }
    }
}