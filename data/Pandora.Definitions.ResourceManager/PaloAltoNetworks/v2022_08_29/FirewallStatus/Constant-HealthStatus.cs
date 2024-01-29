// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.FirewallStatus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthStatusConstant
{
    [Description("GREEN")]
    GREEN,

    [Description("INITIALIZING")]
    INITIALIZING,

    [Description("RED")]
    RED,

    [Description("YELLOW")]
    YELLOW,
}
