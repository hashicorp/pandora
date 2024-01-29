// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.PortalConfig;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PortalSettingsCspModeConstant
{
    [Description("disabled")]
    Disabled,

    [Description("enabled")]
    Enabled,

    [Description("reportOnly")]
    ReportOnly,
}
