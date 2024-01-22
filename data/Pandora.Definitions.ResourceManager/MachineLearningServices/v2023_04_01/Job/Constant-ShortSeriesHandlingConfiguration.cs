// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ShortSeriesHandlingConfigurationConstant
{
    [Description("Auto")]
    Auto,

    [Description("Drop")]
    Drop,

    [Description("None")]
    None,

    [Description("Pad")]
    Pad,
}
