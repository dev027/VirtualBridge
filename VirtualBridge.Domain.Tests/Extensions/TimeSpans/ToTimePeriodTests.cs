// <copyright file="ToTimePeriodTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.Constants;
using VirtualBridge.Domain.Extensions.TimeSpans;

namespace VirtualBridge.Domain.Tests.Extensions.TimeSpans
{
    /// <summary>
    /// Tests for <see cref="TimeSpanExtensions.ToTimePeriod"/>.
    /// </summary>
    [TestClass]
    public class ToTimePeriodTests
    {
        /// <summary>
        /// Tests with various times.
        /// </summary>
        /// <param name="hours">Hour of the day.</param>
        /// <param name="expectedValue">Expected value.</param>
        [TestMethod]
        [DataRow(0, ETimePeriod.Morning)]
        [DataRow(1, ETimePeriod.Morning)]
        [DataRow(2, ETimePeriod.Morning)]
        [DataRow(3, ETimePeriod.Morning)]
        [DataRow(4, ETimePeriod.Morning)]
        [DataRow(5, ETimePeriod.Morning)]
        [DataRow(6, ETimePeriod.Morning)]
        [DataRow(7, ETimePeriod.Morning)]
        [DataRow(8, ETimePeriod.Morning)]
        [DataRow(9, ETimePeriod.Morning)]
        [DataRow(10, ETimePeriod.Morning)]
        [DataRow(11, ETimePeriod.Morning)]
        [DataRow(12, ETimePeriod.Afternoon)]
        [DataRow(13, ETimePeriod.Afternoon)]
        [DataRow(14, ETimePeriod.Afternoon)]
        [DataRow(15, ETimePeriod.Afternoon)]
        [DataRow(16, ETimePeriod.Afternoon)]
        [DataRow(17, ETimePeriod.Afternoon)]
        [DataRow(18, ETimePeriod.Evening)]
        [DataRow(19, ETimePeriod.Evening)]
        [DataRow(20, ETimePeriod.Evening)]
        [DataRow(21, ETimePeriod.Evening)]
        [DataRow(22, ETimePeriod.Evening)]
        [DataRow(23, ETimePeriod.Evening)]
        public void Test_With_Various_Times(int hours, ETimePeriod expectedValue)
        {
            // ARRANGE
            TimeSpan timeToTest = TimeSpan.FromHours(hours);

            // ACT
            ETimePeriod timePeriod = timeToTest.ToTimePeriod();

            // ASSERT
            Assert.AreEqual(expectedValue, timePeriod);
        }

        /// <summary>
        /// Tests with various times over 24 hours.
        /// </summary>
        /// <param name="hours">Hour of the day.</param>
        /// <param name="expectedValue">Expected value.</param>
        [TestMethod]
        [DataRow(0, ETimePeriod.Morning)]
        [DataRow(1, ETimePeriod.Morning)]
        [DataRow(2, ETimePeriod.Morning)]
        [DataRow(3, ETimePeriod.Morning)]
        [DataRow(4, ETimePeriod.Morning)]
        [DataRow(5, ETimePeriod.Morning)]
        [DataRow(6, ETimePeriod.Morning)]
        [DataRow(7, ETimePeriod.Morning)]
        [DataRow(8, ETimePeriod.Morning)]
        [DataRow(9, ETimePeriod.Morning)]
        [DataRow(10, ETimePeriod.Morning)]
        [DataRow(11, ETimePeriod.Morning)]
        [DataRow(12, ETimePeriod.Afternoon)]
        [DataRow(13, ETimePeriod.Afternoon)]
        [DataRow(14, ETimePeriod.Afternoon)]
        [DataRow(15, ETimePeriod.Afternoon)]
        [DataRow(16, ETimePeriod.Afternoon)]
        [DataRow(17, ETimePeriod.Afternoon)]
        [DataRow(18, ETimePeriod.Evening)]
        [DataRow(19, ETimePeriod.Evening)]
        [DataRow(20, ETimePeriod.Evening)]
        [DataRow(21, ETimePeriod.Evening)]
        [DataRow(22, ETimePeriod.Evening)]
        [DataRow(23, ETimePeriod.Evening)]
        public void Test_With_Times_Over_24_Hours(int hours, ETimePeriod expectedValue)
        {
            // ARRANGE
            TimeSpan timeToTest = TimeSpan.FromHours(hours).Add(TimeSpan.FromDays(1));

            // ACT
            ETimePeriod timePeriod = timeToTest.ToTimePeriod();

            // ASSERT
            Assert.AreEqual(expectedValue, timePeriod);
        }
    }
}