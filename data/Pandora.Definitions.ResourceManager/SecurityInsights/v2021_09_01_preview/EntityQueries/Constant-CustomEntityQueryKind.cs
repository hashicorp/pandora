// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.EntityQueries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomEntityQueryKindConstant
{
    [Description("Activity")]
    Activity,
}
