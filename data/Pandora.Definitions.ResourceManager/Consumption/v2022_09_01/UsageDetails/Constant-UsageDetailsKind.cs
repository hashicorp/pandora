// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2022_09_01.UsageDetails;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UsageDetailsKindConstant
{
    [Description("legacy")]
    Legacy,

    [Description("modern")]
    Modern,
}
