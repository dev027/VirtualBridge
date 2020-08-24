// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Attributes;
using VirtualBridge.Data.Models;

namespace VirtualBridge.Data.Tests.Models.PropertyAttributeSummaryTests
{
    /// <summary>
    /// Test the constructor for <see cref="PropertyAttributeSummary"/>.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the with valid values.
        /// </summary>
        [TestMethod]
        public void Test_With_Valid_Values()
        {
            // ARRANGE
            AuditIgnoreAttribute paramAuditIgnore = new AuditIgnoreAttribute();
            ForeignKeyAttribute paramForeignKey = new ForeignKeyAttribute("ForeignKeyProperty");
            KeyAttribute paramKey = new KeyAttribute();
            NotMappedAttribute paramNotMapped = new NotMappedAttribute();
            RangeAttribute paramRange = new RangeAttribute(
                minimum: 1D,
                maximum: 5D);

            // ACT
            PropertyAttributeSummary propertyAttributeSummary = new PropertyAttributeSummary(
                auditIgnore: paramAuditIgnore,
                foreignKey: paramForeignKey,
                key: paramKey,
                notMapped: paramNotMapped,
                range: paramRange);

            // ASSERT
            Assert.AreSame(paramAuditIgnore, propertyAttributeSummary.AuditIgnore);
            Assert.AreSame(paramForeignKey, propertyAttributeSummary.ForeignKey);
            Assert.AreSame(paramKey, propertyAttributeSummary.Key);
            Assert.AreSame(paramNotMapped, propertyAttributeSummary.NotMapped);
            Assert.AreSame(paramRange, propertyAttributeSummary.Range);
        }

        /// <summary>
        /// Tests the with null values.
        /// </summary>
        [TestMethod]
        public void Test_With_Null_Values()
        {
            // ACT
            PropertyAttributeSummary propertyAttributeSummary = new PropertyAttributeSummary(
                auditIgnore: null,
                foreignKey: null,
                key: null,
                notMapped: null,
                range: null);

            // ASSERT
            Assert.IsNull(propertyAttributeSummary.AuditIgnore);
            Assert.IsNull(propertyAttributeSummary.ForeignKey);
            Assert.IsNull(propertyAttributeSummary.Key);
            Assert.IsNull(propertyAttributeSummary.NotMapped);
            Assert.IsNull(propertyAttributeSummary.Range);
        }
    }
}