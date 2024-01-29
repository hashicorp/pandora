// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Outputs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JsonOutputSerializationFormatConstant
{
    [Description("Array")]
    Array,

    [Description("LineSeparated")]
    LineSeparated,
}
