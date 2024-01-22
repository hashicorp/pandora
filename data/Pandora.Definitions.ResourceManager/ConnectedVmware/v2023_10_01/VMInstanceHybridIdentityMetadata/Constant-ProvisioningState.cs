// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VMInstanceHybridIdentityMetadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

    [Description("Created")]
    Created,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Provisioning")]
    Provisioning,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
