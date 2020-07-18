// <copyright file="IsValidTests.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualBridge.Domain.ValidationAttributes;

namespace VirtualBridge.Domain.Tests.ValidationAttributes.ValidIdAttributeTests
{
    /// <summary>
    /// Test the <see cref="ValidIdAttribute.IsValid"/> method.
    /// </summary>
    [TestClass]
    public class IsValidTests
    {
        /// <summary>
        /// Tests that a new Guid is a valid id.
        /// </summary>
        [TestMethod]
        public void TestNewGuidIsValidId()
        {
            // ARRANGE
            Guid paramId = Guid.NewGuid();
            ValidIdAttribute attribute = new ValidIdAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramId);

            // ASSERT
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// Tests that an empty Guid is an invalid id.
        /// </summary>
        [TestMethod]
        public void TestEmptyGuidIsInvalidId()
        {
            // ARRANGE
            Guid paramId = Guid.Empty;
            ValidIdAttribute attribute = new ValidIdAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramId);

            // ASSERT
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests that a non-Guid is an invalid id.
        /// </summary>
        [TestMethod]
        public void TestNonGuidIsInvalidId()
        {
            // ARRANGE
            const int paramId = 1;
            ValidIdAttribute attribute = new ValidIdAttribute();

            // ACT
            bool isValid = attribute.IsValid(paramId);

            // ASSERT
            Assert.IsFalse(isValid);
        }
    }
}