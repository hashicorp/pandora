// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.IoTCentral.v2021_11_01_preview.Apps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PublicNetworkAccessConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
