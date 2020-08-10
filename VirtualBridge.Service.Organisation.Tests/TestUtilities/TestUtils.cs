// <copyright file="TestUtils.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VirtualBridge.Data.DbContexts;

namespace VirtualBridge.Service.Organisation.Tests.TestUtilities
{
    /// <summary>
    /// Test Utilities.
    /// </summary>
    public static class TestUtils
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        public static string ConnectionString =>
            "data source=WRIGHT1\\SQLEXPRESS01;initial catalog=VirtualBridge;Integrated Security=True";

        /// <summary>
        /// Gets the database context options.
        /// </summary>
        public static DbContextOptions<DataContext> DbContextOptions
        {
            get
            {
                DbContextOptionsBuilder<DataContext> builder = new DbContextOptionsBuilder<DataContext>();
                builder.UseSqlServer(TestUtils.ConnectionString);
                return builder.Options;
            }
        }

        /// <summary>
        /// Gets the database context options for In Memory database.
        /// </summary>
        /// <param name="testName">Test Name.</param>
        /// <typeparam name="T">Test Class.</typeparam>
        /// <returns>Database options.</returns>
        public static DbContextOptions<DataContext> DbContextOptionsInMemory<T>(
            string testName)
        {
            if (testName == null)
            {
                throw new ArgumentNullException(nameof(testName));
            }

            Type type = typeof(T);

            return DbContextOptionsInMemory($"{type.FullName}__{testName}");
        }

        /// <summary>
        /// Gets the database context options for In Memory database.
        /// </summary>
        /// <param name="testDatabaseName">Test Database Name.</param>
        /// <returns>Database options.</returns>
        public static DbContextOptions<DataContext> DbContextOptionsInMemory(
            string testDatabaseName)
        {
            if (testDatabaseName == null)
            {
                throw new ArgumentNullException(nameof(testDatabaseName));
            }

            DbContextOptionsBuilder<DataContext> builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseInMemoryDatabase(testDatabaseName)
                .ConfigureWarnings(x => x.Ignore(
                    InMemoryEventId.TransactionIgnoredWarning));
            return builder.Options;
        }

        /// <summary>
        /// Sets the private property value.
        /// </summary>
        /// <typeparam name="T">Property Type.</typeparam>
        /// <param name="target">Target object.</param>
        /// <param name="propName">Property name.</param>
        /// <param name="value">Value to set.</param>
        public static void SetPrivatePropertyValue<T>(
            this object target,
            string propName,
            T value)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            Type t = target.GetType();
            if (t.GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) == null)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(propName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        @"Property {0} was not found in type {1}",
                        propName,
                        target.GetType().FullName));
            }

            t.InvokeMember(
                name: propName,
                invokeAttr: BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance,
                binder: null,
                target: target,
                args: new object[] { value },
                culture: CultureInfo.InvariantCulture);
        }
    }
}