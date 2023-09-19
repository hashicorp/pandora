// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementPartnerPartnerStateConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Unavailable")]
    @unavailable,

    [Description("Enabled")]
    @enabled,

    [Description("Terminated")]
    @terminated,

    [Description("Rejected")]
    @rejected,

    [Description("Unresponsive")]
    @unresponsive,
}
