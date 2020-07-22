// <copyright file="IsValidTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.ValidationAttributes;

namespace VirtualBridge.Domain.Tests.ValidationAttributes.ValidTimeOfDayAttributeTests
{
    /// <summary>
    /// Test the <see cref="ValidTimeOfDayAttribute.IsValid"/> method.
    /// </summary>
    [TestClass]
    public class IsValidTests
    {
        /// <summary>
        /// Tests that a null is a valid time of day.
        /// </summary>
        [TestMethod]
        public void TestNullIsValidTimeOfDay()
        {
            // ARRANGE
            ValidTimeOfDayAttribute attribute = new ValidTimeOfDayAttribute();

            // ACT
            bool isValid = attribute.IsValid(null!);

            // ASSERT
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// Test that 00:00 is valid time of day.
        /// </summary>
        [TestMethod]
        public void Test0000IsValidTimeOfDay()
        {
            // ARRANGE
            TimeSpan paramTimeOfDay = new TimeSpan(0, 0, 0);
            ValidTimeOfDayAttribute attribute = new ValidTimeOfDayAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramTimeOfDay);

            // ASSERT
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// Test that 23:59 is valid time of day.
        /// </summary>
        [TestMethod]
        public void Test2359IsValidTimeOfDay()
        {
            // ARRANGE
            TimeSpan paramTimeOfDay = new TimeSpan(23, 59, 0);
            ValidTimeOfDayAttribute attribute = new ValidTimeOfDayAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramTimeOfDay);

            // ASSERT
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// Tests that afternoon time with minutes is valid.
        /// </summary>
        [TestMethod]
        public void TestAfternoonTimeWithMinutesIsValid()
        {
            // ARRANGE
            TimeSpan paramTimeOfDay = new TimeSpan(14, 13, 0);
            ValidTimeOfDayAttribute attribute = new ValidTimeOfDayAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramTimeOfDay);

            // ASSERT
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// Tests that negative time is invalid.
        /// </summary>
        [TestMethod]
        public void TestNegativeTimeIsInvalid()
        {
            // ARRANGE
            TimeSpan paramTimeOfDay = -1 * new TimeSpan(14, 13, 0);
            ValidTimeOfDayAttribute attribute = new ValidTimeOfDayAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramTimeOfDay);

            // ASSERT
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Test that exactly 24 hours is invalid.
        /// </summary>
        [TestMethod]
        public void TestExactly24HoursIsInvalid()
        {
            // ARRANGE
            TimeSpan paramTimeOfDay = new TimeSpan(1, 0, 0, 0);
            ValidTimeOfDayAttribute attribute = new ValidTimeOfDayAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramTimeOfDay);

            // ASSERT
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests that more than one day is invalid.
        /// </summary>
        [TestMethod]
        public void TestMoreThanOneDayIsInvalid()
        {
            // ARRANGE
            TimeSpan paramTimeOfDay = new TimeSpan(1, 1, 0, 0);
            ValidTimeOfDayAttribute attribute = new ValidTimeOfDayAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramTimeOfDay);

            // ASSERT
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests that a time with seconds is invalid.
        /// </summary>
        [TestMethod]
        public void TestWithSecondsIsInvalid()
        {
            // ARRANGE
            TimeSpan paramTimeOfDay = new TimeSpan(14, 13, 23);
            ValidTimeOfDayAttribute attribute = new ValidTimeOfDayAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramTimeOfDay);

            // ASSERT
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests that a time with milliseconds is invalid.
        /// </summary>
        [TestMethod]
        public void TestWithMillisecondsIsInvalid()
        {
            // ARRANGE
            TimeSpan paramTimeOfDay = new TimeSpan(14, 13, 00);
            paramTimeOfDay += TimeSpan.FromMilliseconds(15);
            ValidTimeOfDayAttribute attribute = new ValidTimeOfDayAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramTimeOfDay);

            // ASSERT
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests that a non-timeSpan is invalid.
        /// </summary>
        [TestMethod]
        public void TestNonTimeSpanIsInvalid()
        {
            // ARRANGE
            DateTime paramTimeOfDay = DateTime.Today;
            ValidTimeOfDayAttribute attribute = new ValidTimeOfDayAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramTimeOfDay);

            // ASSERT
            Assert.IsFalse(isValid);
        }
    }
}