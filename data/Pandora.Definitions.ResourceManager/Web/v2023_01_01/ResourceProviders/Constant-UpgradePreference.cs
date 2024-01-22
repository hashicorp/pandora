// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ResourceProviders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpgradePreferenceConstant
{
    [Description("Early")]
    Early,

    [Description("Late")]
    Late,

    [Description("Manual")]
    Manual,

    [Description("None")]
    None,
}
