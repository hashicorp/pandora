// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContinuousAccessEvaluationModeConstant
{
    [Description("StrictEnforcement")]
    @strictEnforcement,

    [Description("Disabled")]
    @disabled,

    [Description("StrictLocation")]
    @strictLocation,
}
