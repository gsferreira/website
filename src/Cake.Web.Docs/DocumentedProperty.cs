﻿using System.Collections.Generic;
using System.Diagnostics;
using Cake.Web.Docs.Comments;
using Cake.Web.Docs.Reflection;
using Cake.Web.Docs.Reflection.Model;
using Mono.Cecil;

namespace Cake.Web.Docs
{
    /// <summary>
    /// Represents a documented property.
    /// </summary>
    [DebuggerDisplay("{Identity,nq}")]
    public sealed class DocumentedProperty : DocumentedMember
    {
        private readonly PropertyDefinition _definition;
        private readonly string _identity;
        private readonly ValueComment _value;

        /// <summary>
        /// Gets the property's identity.
        /// </summary>
        /// <value>The method's identity.</value>
        public string Identity
        {
            get { return _identity; }
        }

        /// <summary>
        /// Gets the declaring type.
        /// </summary>
        /// <value>The declaring type.</value>
        public DocumentedType Type { get; internal set; }

        /// <summary>
        /// Gets the property definition.
        /// </summary>
        /// <value>The property definition.</value>
        public PropertyDefinition Definition
        {
            get { return _definition; }
        }

        /// <summary>
        /// Gets the value comment.
        /// </summary>
        /// <value>The value comment.</value>
        public ValueComment Value
        {
            get { return _value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentedProperty" /> class.
        /// </summary>
        /// <param name="info">The property info.</param>
        /// <param name="summary">The summary comment.</param>
        /// <param name="remarks">The remarks comment.</param>
        /// <param name="examples">The example comments.</param>
        /// <param name="value">The value comment.</param>
        public DocumentedProperty(
            IPropertyInfo info,
            SummaryComment summary,
            RemarksComment remarks,
            IEnumerable<ExampleComment> examples,
            ValueComment value)
            : base(MemberClassification.Property, summary, remarks, examples)
        {
            _definition = info.Definition;
            _identity = info.Identity;
            _value = value;
        }
    }
}