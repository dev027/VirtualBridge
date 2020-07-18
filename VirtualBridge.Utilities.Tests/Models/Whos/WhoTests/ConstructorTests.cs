// <copyright file="ConstructorTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Utilities.Models.Whos;

namespace VirtualBridge.Utilities.Tests.Models.Whos.WhoTests
{
    /// <summary>
    /// Test the constructor for <see cref="Who"/>.
    /// </summary>
    [TestClass]
    public class ConstructorTests
    {
        /// <summary>
        /// Tests the constructor with valid values.
        /// </summary>
        [TestMethod]
        public void TestConstructorWithValidValues()
        {
            // ARRANGE
            const string paramControllerName = "ControllerName";
            const string paramActionName = "ActionName";
            const string paramPath = "/Home/Index";
            const string paramQueryString = "?id=15";

            // ACT
            IWho who = new Who(
                controllerName: paramControllerName,
                actionName: paramActionName,
                path: paramPath,
                queryString: paramQueryString);

            // ASSERT
            Assert.AreNotEqual(Guid.Empty, who.CorrelationId);
            Assert.AreEqual(paramControllerName, who.ControllerName);
            Assert.AreEqual(paramActionName, who.ActionName);
            Assert.AreEqual(paramPath, who.Path);
            Assert.AreEqual(paramQueryString, who.QueryString);
        }

        /// <summary>
        /// Tests the constructor with null controller name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorWithNullControllerNameThrowsException()
        {
            // ARRANGE
            const string paramActionName = "ActionName";
            const string paramPath = "/Home/Index";
            const string paramQueryString = "?id=15";

            // ACT
            _ = new Who(
                controllerName: null!,
                actionName: paramActionName,
                path: paramPath,
                queryString: paramQueryString);
        }

        /// <summary>
        /// Tests the constructor with null action name throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorWithNullActionNameThrowsException()
        {
            // ARRANGE
            const string paramControllerName = "ControllerName";
            const string paramPath = "/Home/Index";
            const string paramQueryString = "?id=15";

            // ACT
            _ = new Who(
                controllerName: paramControllerName,
                actionName: null!,
                path: paramPath,
                queryString: paramQueryString);
        }

        /// <summary>
        /// Tests the constructor with null path throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorWithNullPathThrowsException()
        {
            // ARRANGE
            const string paramControllerName = "ControllerName";
            const string paramActionName = "ActionName";
            const string paramQueryString = "?id=15";

            // ACT
            _ = new Who(
                controllerName: paramControllerName,
                actionName: paramActionName,
                path: null!,
                queryString: paramQueryString);
        }

        /// <summary>
        /// Tests the constructor with null query string throws exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorWithNullQueryStringThrowsException()
        {
            // ARRANGE
            const string paramControllerName = "ControllerName";
            const string paramActionName = "ActionName";
            const string paramPath = "/Home/Index";

            // ACT
            _ = new Who(
                controllerName: paramControllerName,
                actionName: paramActionName,
                path: paramPath,
                queryString: null!);
        }
    }
}