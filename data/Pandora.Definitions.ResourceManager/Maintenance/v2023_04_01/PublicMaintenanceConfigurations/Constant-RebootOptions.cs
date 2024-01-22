// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2023_04_01.PublicMaintenanceConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RebootOptionsConstant
{
    [Description("Always")]
    Always,

    [Description("IfRequired")]
    IfRequired,

    [Description("Never")]
    Never,
}
