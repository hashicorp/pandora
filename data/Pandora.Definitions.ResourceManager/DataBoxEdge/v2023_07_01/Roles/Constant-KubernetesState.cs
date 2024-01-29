// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2023_07_01.Roles;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KubernetesStateConstant
{
    [Description("Created")]
    Created,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Invalid")]
    Invalid,

    [Description("Reconfiguring")]
    Reconfiguring,

    [Description("Updating")]
    Updating,
}
