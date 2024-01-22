// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WorkflowTriggers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkflowTriggerProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

    [Description("Completed")]
    Completed,

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

    [Description("Moving")]
    Moving,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Ready")]
    Ready,

    [Description("Registered")]
    Registered,

    [Description("Registering")]
    Registering,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,

    [Description("Unregistered")]
    Unregistered,

    [Description("Unregistering")]
    Unregistering,

    [Description("Updating")]
    Updating,
}
