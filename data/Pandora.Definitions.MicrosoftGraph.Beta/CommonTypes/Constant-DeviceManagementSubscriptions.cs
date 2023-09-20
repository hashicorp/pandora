// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementSubscriptionsConstant
{
    [Description("None")]
    @none,

    [Description("Intune")]
    @intune,

    [Description("Office365")]
    @office365,

    [Description("IntunePremium")]
    @intunePremium,

    [Description("IntuneEDU")]
    @intune_EDU,

    [Description("IntuneSMB")]
    @intune_SMB,
}
