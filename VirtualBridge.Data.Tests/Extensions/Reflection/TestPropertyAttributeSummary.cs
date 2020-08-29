// <copyright file="TestPropertyAttributeSummary.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Attributes;
using VirtualBridge.Data.Extensions.Reflection;
using VirtualBridge.Data.Models;

namespace VirtualBridge.Data.Tests.Extensions.Reflection
{
    /// <summary>
    /// Tests for <see cref="ReflectionExtensions.GetAttributes"/>.
    /// </summary>
    [TestClass]
    public class TestPropertyAttributeSummary
    {
        /// <summary>
        /// Tests reading property with attributes.
        /// </summary>
        [TestMethod]
        public void Test_Reading_Property_With_Attributes()
        {
            // ARRANGE
            const string propertyName = nameof(MyTestClass.PropertyWithAttributes);
            MyTestClass testObj = new MyTestClass();
            Type type = testObj.GetType();

            PropertyDescriptorCollection propertyDescriptors = TypeDescriptor.GetProperties(type);
            PropertyDescriptor propertyDescriptor = propertyDescriptors[propertyName];

            // ACT
            PropertyAttributeSummary attributes = propertyDescriptor.GetAttributes();

            // ASSERT
            Assert.IsNotNull(attributes);
            Assert.IsNotNull(attributes.AuditIgnore);
            Assert.IsNotNull(attributes.ForeignKey);
            Assert.IsNotNull(attributes.Key);
            Assert.IsNotNull(attributes.NotMapped);
            Assert.IsNotNull(attributes.Range);
        }

        /// <summary>
        /// Tests  reading property without attributes.
        /// </summary>
        [TestMethod]
        public void Test_Reading_Property_Without_Attributes()
        {
            // ARRANGE
            const string propertyName = nameof(MyTestClass.PropertyWithoutAttributes);
            MyTestClass testObj = new MyTestClass();
            Type type = testObj.GetType();

            PropertyDescriptorCollection propertyDescriptors = TypeDescriptor.GetProperties(type);
            PropertyDescriptor propertyDescriptor = propertyDescriptors[propertyName];

            // ACT
            PropertyAttributeSummary attributes = propertyDescriptor.GetAttributes();

            // ASSERT
            Assert.IsNotNull(attributes);
            Assert.IsNull(attributes.AuditIgnore);
            Assert.IsNull(attributes.ForeignKey);
            Assert.IsNull(attributes.Key);
            Assert.IsNull(attributes.NotMapped);
            Assert.IsNull(attributes.Range);
        }

        /// <summary>
        /// Tests the reading null property throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Reading_Null_Property_Throws_Exception()
        {
            // ACT
            _ = ((PropertyDescriptor)null) !.GetAttributes();
        }

        private class MyTestClass
        {
            [AuditIgnore]
            [ForeignKey("ForeignKey")]
            [Key]
            [NotMapped]
            [Range(1, 5)]
            public int PropertyWithAttributes { get; set; }

            public int PropertyWithoutAttributes { get; set; } = 1;
        }
    }
}