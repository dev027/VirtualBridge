// <copyright file="ReflectionExtensions.cs" company="Do It Wright">
// Copyright (c) Do It Wright. All rights reserved.
// </copyright>

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using VirtualBridge.Data.Attributes;
using VirtualBridge.Data.Models;

namespace VirtualBridge.Data.Extensions
{
    /// <summary>
    /// Reflection Extension methods.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Gets the Property Value from the Object as a string.
        /// </summary>
        /// <param name="propertyInfo">Property Information.</param>
        /// <param name="o">Object.</param>
        /// <returns>Property Value as a sting.</returns>
        public static string GetValueAsString(
            this PropertyInfo propertyInfo,
            object o)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            if (o is null)
            {
                throw new ArgumentNullException(nameof(o));
            }

            MethodInfo getMethod = propertyInfo.GetGetMethod();

            object propertyValue = getMethod.Invoke(o, null);

            return propertyValue == null
                ? string.Empty
                : propertyValue.ToString();
        }

        /// <summary>
        /// Determines whether this instance is a collection.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified instance is collection; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCollection(this PropertyInfo instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            // If it's not IEnumerable then it cannot be a collection
            if (instance.PropertyType.GetInterface(nameof(IEnumerable)) == null)
            {
                return false;
            }

            // Strings are IEnumerable but they don't count as collections
            return instance.PropertyType != typeof(string);
        }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <param name="instance">The Instance.</param>
        /// <returns>Property Attributes.</returns>
        public static PropertyAttributeSummary GetAttributes(this PropertyDescriptor instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            return new PropertyAttributeSummary(
                (AuditIgnoreAttribute?)instance.Attributes[typeof(AuditIgnoreAttribute)],
                (ForeignKeyAttribute?)instance.Attributes[typeof(ForeignKeyAttribute)],
                (KeyAttribute?)instance.Attributes[typeof(KeyAttribute)],
                (NotMappedAttribute?)instance.Attributes[typeof(NotMappedAttribute)],
                (RangeAttribute?)instance.Attributes[typeof(RangeAttribute)]);
        }
    }
}