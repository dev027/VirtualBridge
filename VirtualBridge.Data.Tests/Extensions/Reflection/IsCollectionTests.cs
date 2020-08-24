// <copyright file="IsCollectionTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Extensions.Reflection;

namespace VirtualBridge.Data.Tests.Extensions.Reflection
{
    /// <summary>
    /// Test <see cref="ReflectionExtensions.IsCollection"/>.
    /// </summary>
    [TestClass]
    public class IsCollectionTests
    {
        /// <summary>
        /// Tests if property is a collection.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="expectedIsCollection">if set to <c>true</c> [expected is collection].</param>
        /// <exception cref="InvalidOperationException">Cannot find property <c>propertyName</c>.</exception>
        [TestMethod]
        [DataRow(nameof(MyTestClass.MyInt), false, DisplayName = "Integer")]
        [DataRow(nameof(MyTestClass.MyString), false, DisplayName = "String")]
        [DataRow(nameof(MyTestClass.MyInterfaceList), true, DisplayName = "IList")]
        [DataRow(nameof(MyTestClass.MyList), true, DisplayName = "List")]
        [DataRow(nameof(MyTestClass.MyInterfaceDictionary), true, DisplayName = "IDictionary")]
        [DataRow(nameof(MyTestClass.MyDictionary), true, DisplayName = "Dictionary")]
        public void Test_If_Property_Is_A_Collection(
            string propertyName,
            bool expectedIsCollection)
        {
            // ARRANGE
            _ = new MyTestClass();
            PropertyInfo property = typeof(MyTestClass).GetProperty(propertyName);

            if (property == null)
            {
                throw new InvalidOperationException($"Cannot find property {propertyName}");
            }

            // ACT
            var actualIsCollection = property.IsCollection();

            // ASSERT
            Assert.AreEqual(expectedIsCollection, actualIsCollection);
        }

        /// <summary>
        /// Tests that a null property throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Null_Property_Throws_Exception()
        {
            // ARRANGE
            PropertyInfo property = typeof(MyTestClass).GetProperty("Unknown");

            // ACT
            _ = property!.IsCollection();
        }

        private class MyTestClass
        {
            public MyTestClass()
            {
                this.MyInt = 1;
                this.MyString = string.Empty;
                this.MyInterfaceList = new List<int>();
                this.MyList = new List<int>();
                this.MyInterfaceDictionary = new Dictionary<int, int>();
                this.MyDictionary = new Dictionary<int, int>();
            }

            public int MyInt { get; set; }

            public string MyString { get; set; }

            public IList<int> MyInterfaceList { get; set; }

            public List<int> MyList { get; set; }

            public IDictionary<int, int> MyInterfaceDictionary { get; set; }

            public Dictionary<int, int> MyDictionary { get; set; }
        }
    }
}