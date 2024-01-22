// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Catalogs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

    [Description("Created")]
    Created,

    [Description("Creating")]
    Creating,

    [Description("Deleted")]
    Deleted,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("MovingResources")]
    MovingResources,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("RolloutInProgress")]
    RolloutInProgress,

    [Description("Running")]
    Running,

    [Description("StorageProvisioningFailed")]
    StorageProvisioningFailed,

    [Description("Succeeded")]
    Succeeded,

    [Description("TransientFailure")]
    TransientFailure,

    [Description("Updated")]
    Updated,

    [Description("Updating")]
    Updating,
}
