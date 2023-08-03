// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidDeviceOwnerAppAutoUpdatePolicyTypeConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("UserChoice")]
    @userChoice,

    [Description("Never")]
    @never,

    [Description("WiFiOnly")]
    @wiFiOnly,

    [Description("Always")]
    @always,
}
