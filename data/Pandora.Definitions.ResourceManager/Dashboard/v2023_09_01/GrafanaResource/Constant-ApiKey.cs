// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Dashboard.v2023_09_01.GrafanaResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApiKeyConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
