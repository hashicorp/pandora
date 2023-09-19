// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FilterOperatorSchemaSupportedAttributeTypesConstant
{
    [Description("String")]
    @String,

    [Description("Integer")]
    @Integer,

    [Description("Reference")]
    @Reference,

    [Description("Binary")]
    @Binary,

    [Description("Boolean")]
    @Boolean,

    [Description("DateTime")]
    @DateTime,
}
