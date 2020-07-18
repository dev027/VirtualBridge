// <copyright file="ValidateTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.DomainObjects;

namespace VirtualBridge.Domain.Tests.DomainObjects.BaseDomainModelTests
{
    /// <summary>
    /// Tests for <see cref="BaseDomainModel.Validate"/>.
    /// </summary>
    [TestClass]
    public class ValidateTests
    {
        /// <summary>
        /// Tests that multiple validation errors throws an aggregate exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestMultipleValidationErrorsThrowsAggregateException()
        {
            // ACT
            _ = new MyTestClass();
        }

        /// <summary>
        /// Test Class inheriting from BaseDomainModel.
        /// </summary>
        /// <seealso cref="BaseDomainModel" />
        private class MyTestClass : BaseDomainModel
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MyTestClass"/> class.
            /// </summary>
            public MyTestClass()
            {
                this.Property1 = null;
                this.Property2 = null;

                Validate(this);
            }

            /// <summary>
            /// Gets the property1.
            /// </summary>
            [Required]
            public string Property1 { get; }

            /// <summary>
            /// Gets the property2.
            /// </summary>
            [Required]
            public string Property2 { get; }
        }
    }
}