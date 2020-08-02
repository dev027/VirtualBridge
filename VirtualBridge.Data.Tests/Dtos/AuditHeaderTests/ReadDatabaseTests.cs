// <copyright file="ReadDatabaseTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.DbContexts;
using VirtualBridge.Data.Tests.TestUtilities;

namespace VirtualBridge.Data.Tests.Dtos.AuditHeaderTests
{
    /// <summary>
    /// Read database tests.
    /// </summary>
    [TestClass]
    public class ReadDatabaseTests
    {
        /// <summary>
        /// Tests the read from database.
        /// </summary>
        [TestMethod]
        public void Test_Read_From_Database()
        {
            using DataContext context = new DataContext(
                TestUtils.DbContextOptionsInMemory(nameof(ReadDatabaseTests)));

            _ = context.AuditHeaders.Any();
            _ = context.AuditHeaders.FirstOrDefault();
        }
    }
}