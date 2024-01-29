// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2021_06_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkspaceEntityStatusConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("ProvisioningAccount")]
    ProvisioningAccount,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
