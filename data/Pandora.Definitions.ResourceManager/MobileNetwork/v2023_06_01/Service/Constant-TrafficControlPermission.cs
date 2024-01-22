// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.Service;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TrafficControlPermissionConstant
{
    [Description("Blocked")]
    Blocked,

    [Description("Enabled")]
    Enabled,
}
