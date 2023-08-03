// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsSModeConfigurationConstant
{
    [Description("NoRestriction")]
    @noRestriction,

    [Description("Block")]
    @block,

    [Description("Unlock")]
    @unlock,
}
