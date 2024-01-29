// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.VirtualNetworkRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkRuleStateConstant
{
    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Initializing")]
    Initializing,

    [Description("Ready")]
    Ready,

    [Description("Unknown")]
    Unknown,
}
