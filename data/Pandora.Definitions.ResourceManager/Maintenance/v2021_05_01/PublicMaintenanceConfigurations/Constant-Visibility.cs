// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2021_05_01.PublicMaintenanceConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VisibilityConstant
{
    [Description("Custom")]
    Custom,

    [Description("Public")]
    Public,
}
