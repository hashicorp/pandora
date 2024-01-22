// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.CloudLinks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudLinkStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Building")]
    Building,

    [Description("Deleting")]
    Deleting,

    [Description("Disconnected")]
    Disconnected,

    [Description("Failed")]
    Failed,
}
