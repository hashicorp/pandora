// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.InventoryItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InventoryTypeConstant
{
    [Description("Cluster")]
    Cluster,

    [Description("Datastore")]
    Datastore,

    [Description("Host")]
    Host,

    [Description("ResourcePool")]
    ResourcePool,

    [Description("VirtualMachine")]
    VirtualMachine,

    [Description("VirtualMachineTemplate")]
    VirtualMachineTemplate,

    [Description("VirtualNetwork")]
    VirtualNetwork,
}
