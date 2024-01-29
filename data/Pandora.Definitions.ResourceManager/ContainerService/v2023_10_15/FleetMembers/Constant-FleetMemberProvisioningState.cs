// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.FleetMembers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FleetMemberProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("Joining")]
    Joining,

    [Description("Leaving")]
    Leaving,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
