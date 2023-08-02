// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatorTypeConstant
{
    [Description("GreaterOrEqual")]
    @greaterOrEqual,

    [Description("Equal")]
    @equal,

    [Description("Greater")]
    @greater,

    [Description("Less")]
    @less,

    [Description("LessOrEqual")]
    @lessOrEqual,

    [Description("NotEqual")]
    @notEqual,
}
