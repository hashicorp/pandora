// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2022_10_01.Deviceupdates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoleConstant
{
    [Description("Failover")]
    Failover,

    [Description("Primary")]
    Primary,
}
