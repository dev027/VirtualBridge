﻿// <copyright file="ReadDatabaseTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.DbContexts;
using VirtualBridge.Data.Tests.TestUtilities;

namespace VirtualBridge.Data.Tests.Dtos.OrganisationTests
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
            // ARRANGE
            using DataContext context = new DataContext(
                TestUtils.DbContextOptionsInMemory(nameof(ReadDatabaseTests)));

            // ACT
            _ = context.Organisations.Any();
            _ = context.Organisations.FirstOrDefault();

            // ASSERT
            Assert.IsTrue(true);
        }
    }
}