// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceHealthAttestationStateSystemManagementModeConstant
{
    [Description("NotApplicable")]
    @notApplicable,

    [Description("Level1")]
    @level1,

    [Description("Level2")]
    @level2,

    [Description("Level3")]
    @level3,
}
