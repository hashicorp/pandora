// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.Metrics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResultTypeConstant
{
    [Description("Data")]
    Data,

    [Description("Metadata")]
    Metadata,
}
