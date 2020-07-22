// <copyright file="IsValidTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.ValidationAttributes;

namespace VirtualBridge.Domain.Tests.ValidationAttributes.ValidTimePeriodAttributeTests
{
    /// <summary>
    /// Tests for <see cref="ValidTimeOfDayAttribute.IsValid"/>.
    /// </summary>
    [TestClass]
    public class IsValidTests
    {
        /// <summary>
        /// Tests that an unknown time of day property throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUnknownTimeOfDayPropertyThrowsException()
        {
            // ARRANGE
            ValidTimePeriodAttribute attribute = new ValidTimePeriodAttribute("UnknownTimeOfDayProperty");
            TestClass testObj = new TestClass(new TimeSpan(10, 0, 0));

            // ACT
            _ = attribute.GetValidationResult(
                value: "Anything",
                validationContext: new ValidationContext(testObj));
        }

        /// <summary>
        /// Tests that when time of day property is null then it is always valid.
        /// </summary>
        /// <param name="timePeriod">The time period.</param>
        [TestMethod]
        [DataRow(ETimePeriod.Morning)]
        [DataRow(ETimePeriod.Afternoon)]
        [DataRow(ETimePeriod.Evening)]
        public void TestNullTimeOfDayPropertyIsValid(ETimePeriod timePeriod)
        {
            // ARRANGE
            ValidTimePeriodAttribute attribute = new ValidTimePeriodAttribute(nameof(TestClass.TimeOfDay));
            TestClass testObj = new TestClass(null);

            // ACT
            ValidationResult validationResult = attribute.GetValidationResult(
                value: timePeriod,
                validationContext: new ValidationContext(testObj));

            // ASSERT
            Assert.AreEqual(ValidationResult.Success, validationResult);
        }

        /// <summary>
        /// Tests that when time of day property is invalid then it is always valid.
        /// </summary>
        /// <param name="timePeriod">The time period.</param>
        [TestMethod]
        [DataRow(ETimePeriod.Morning)]
        [DataRow(ETimePeriod.Afternoon)]
        [DataRow(ETimePeriod.Evening)]
        public void TestInvalidTimeOfDayPropertyIsValid(ETimePeriod timePeriod)
        {
            // ARRANGE
            ValidTimePeriodAttribute attribute = new ValidTimePeriodAttribute(nameof(TestClass.TimeOfDay));
            TestClass testObj = new TestClass(new TimeSpan(5, 0, 0, 0));

            // ACT
            ValidationResult validationResult = attribute.GetValidationResult(
                value: timePeriod,
                validationContext: new ValidationContext(testObj));

            // ASSERT
            Assert.AreEqual(ValidationResult.Success, validationResult);
        }

        /// <summary>
        /// Tests that a morning time with afternoon time period is invalid.
        /// </summary>
        [TestMethod]
        public void TestMorningTimeWithAfternoonTimePeriodIsInvalid()
        {
            // ARRANGE
            ValidTimePeriodAttribute attribute = new ValidTimePeriodAttribute(nameof(TestClass.TimeOfDay));
            TestClass testObj = new TestClass(new TimeSpan(10, 0, 0));

            // ACT
            ValidationResult validationResult = attribute.GetValidationResult(
                value: ETimePeriod.Afternoon,
                validationContext: new ValidationContext(testObj));

            // ASSERT
            Assert.IsNotNull(validationResult);
            Assert.AreNotEqual(ValidationResult.Success, validationResult);
            Assert.AreEqual("TestClass is inconsistent with TimeOfDay.", validationResult.ErrorMessage);
        }

        /// <summary>
        /// Tests that a non-ETimePeriod is invalid.
        /// </summary>
        [TestMethod]
        public void TestNonETimePeriodIsInvalid()
        {
            // ARRANGE
            ValidTimePeriodAttribute attribute = new ValidTimePeriodAttribute(nameof(TestClass.TimeOfDay));
            TestClass testObj = new TestClass(new TimeSpan(10, 0, 0));

            // ACT
            ValidationResult validationResult = attribute.GetValidationResult(
                value: "Not an ETimePeriod",
                validationContext: new ValidationContext(testObj));

            // ASSERT
            Assert.AreNotEqual(ValidationResult.Success, validationResult);
            Assert.AreEqual("Attribute can only be used on a ETimePeriod", validationResult?.ErrorMessage);
        }

        private class TestClass
        {
            public TestClass(TimeSpan? timeOfDay)
            {
                this.TimeOfDay = timeOfDay;
            }

            /// <summary>
            /// Gets the Time of Day.
            /// </summary>
            public TimeSpan? TimeOfDay { get; }
        }
    }
}