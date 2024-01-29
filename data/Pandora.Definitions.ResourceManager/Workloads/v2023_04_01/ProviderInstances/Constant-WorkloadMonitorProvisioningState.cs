// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.ProviderInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkloadMonitorProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Migrating")]
    Migrating,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
