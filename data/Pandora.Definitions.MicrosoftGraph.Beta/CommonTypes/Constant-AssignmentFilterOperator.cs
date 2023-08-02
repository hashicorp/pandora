// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssignmentFilterOperatorConstant
{
    [Description("NotSet")]
    @notSet,

    [Description("Equals")]
    @equals,

    [Description("NotEquals")]
    @notEquals,

    [Description("StartsWith")]
    @startsWith,

    [Description("NotStartsWith")]
    @notStartsWith,

    [Description("Contains")]
    @contains,

    [Description("NotContains")]
    @notContains,

    [Description("In")]
    @in,

    [Description("NotIn")]
    @notIn,

    [Description("EndsWith")]
    @endsWith,

    [Description("NotEndsWith")]
    @notEndsWith,
}
