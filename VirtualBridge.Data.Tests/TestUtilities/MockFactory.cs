// <copyright file="MockFactory.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using Microsoft.Extensions.Logging;
using Moq;

namespace VirtualBridge.Data.Tests.TestUtilities
{
    /// <summary>
    /// Mock Factory.
    /// </summary>
    internal static class MockFactory
    {
        /// <summary>
        /// Creates mock for <see cref="ILogger"/>.
        /// </summary>
        /// <typeparam name="T">Type of the class being logged.</typeparam>
        /// <returns>Logger Mock.</returns>
        internal static Mock<ILogger<T>> CreateLoggerMock<T>()
            => new Mock<ILogger<T>>(MockBehavior.Loose);

        /// <summary>
        /// Creates the repository mock.
        /// </summary>
        /// <typeparam name="T">Repository interface.</typeparam>
        /// <returns>Repository mock.</returns>
        internal static Mock<T> CreateRepositoryMock<T>()
        where T : class
        {
            return new Mock<T>(MockBehavior.Strict);
        }
    }
}