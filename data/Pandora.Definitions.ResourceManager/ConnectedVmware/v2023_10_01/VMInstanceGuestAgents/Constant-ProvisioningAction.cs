// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VMInstanceGuestAgents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningActionConstant
{
    [Description("install")]
    Install,

    [Description("repair")]
    Repair,

    [Description("uninstall")]
    Uninstall,
}
