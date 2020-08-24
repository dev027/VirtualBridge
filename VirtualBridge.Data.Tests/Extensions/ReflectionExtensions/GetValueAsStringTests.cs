// <copyright file="GetValueAsStringTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Data.Extensions;

namespace VirtualBridge.Data.Tests.Extensions.ReflectionExtensions
{
    /// <summary>
    /// Test <see cref="ReflectionExtensions"/> GetValueAsString().
    /// </summary>
    [TestClass]
    public class GetValueAsStringTests
    {
        /// <summary>
        /// Tests the read numeric value as string.
        /// </summary>
        [TestMethod]
        public void Test_Read_Numeric_Value_As_String()
        {
            // ARRANGE
            TestThing thing = new TestThing();

            Type type = thing.GetType();
            PropertyInfo propertyInfo = type.GetProperties()
                .Single(p => p.Name == nameof(TestThing.MyPropertyLong));

            // ACT
            string result = propertyInfo.GetValueAsString(thing);

            // ASSERT
            Assert.AreEqual("1", result);
        }

        /// <summary>
        /// Tests the read null value returns empty string.
        /// </summary>
        [TestMethod]
        public void Test_Read_Null_Value_Returns_Empty_String()
        {
            // ARRANGE
            TestThing thing = new TestThing();

            Type type = thing.GetType();
            PropertyInfo propertyInfo = type.GetProperties()
                .Single(p => p.Name == nameof(TestThing.MyPropertyNullableLong));

            // ACT
            string result = propertyInfo.GetValueAsString(thing);

            // ASSERT
            Assert.AreEqual(string.Empty, result);
        }

        /// <summary>
        /// Tests the read object returns its to string.
        /// </summary>
        [TestMethod]
        public void Test_Read_Object_Returns_Its_ToString()
        {
            // ARRANGE
            TestThing thing = new TestThing();

            Type type = thing.GetType();
            PropertyInfo propertyInfo = type.GetProperties()
                .Single(p => p.Name == nameof(TestThing.MyPropertySomething));

            // ACT
            string result = propertyInfo.GetValueAsString(thing);

            // ASSERT
            Assert.AreEqual("My To String", result);
        }

        /// <summary>
        /// Tests the passing null property information throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Passing_Null_PropertyInfo_Throws_Exception()
        {
            // ARRANGE
            TestThing thing = new TestThing();

            // ACT
            _ = ((PropertyInfo)null) !.GetValueAsString(thing);
        }

        /// <summary>
        /// Tests the passing null object throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Passing_Null_Object_Throws_Exception()
        {
            // ARRANGE
            TestThing thing = new TestThing();

            Type type = thing.GetType();
            PropertyInfo propertyInfo = type.GetProperties()
                .Single(p => p.Name == nameof(TestThing.MyPropertySomething));

            // ACT
            _ = propertyInfo.GetValueAsString(null!);
        }

        /// <summary>
        /// Test object.
        /// </summary>
        private class TestThing
        {
            /// <summary>
            /// Gets my property long.
            /// </summary>
            /// <value>
            /// Always 1.
            /// </value>
            public long MyPropertyLong { get; } = 1;

            /// <summary>
            /// Gets my property nullable long.
            /// </summary>
            /// <value>
            /// Always null.
            /// </value>
            public long? MyPropertyNullableLong { get; } = null!;

            /// <summary>
            /// Gets my property something.
            /// </summary>
            /// <value>
            /// A something.
            /// </value>
            public Something MyPropertySomething { get; } = new Something();
        }

        /// <summary>
        /// Used to test that a class can be read.
        /// </summary>
        private class Something
        {
            /// <summary>
            /// Converts to string.
            /// </summary>
            /// <returns>
            /// A <see cref="string" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return "My To String";
            }
        }
    }
}