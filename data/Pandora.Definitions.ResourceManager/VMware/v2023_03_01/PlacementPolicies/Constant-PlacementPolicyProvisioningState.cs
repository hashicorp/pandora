// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.PlacementPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PlacementPolicyProvisioningStateConstant
{
    [Description("Building")]
    Building,

    [Description("Canceled")]
    Canceled,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
