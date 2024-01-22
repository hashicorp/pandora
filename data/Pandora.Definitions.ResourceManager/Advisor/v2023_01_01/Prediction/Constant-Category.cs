// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2023_01_01.Prediction;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CategoryConstant
{
    [Description("Cost")]
    Cost,

    [Description("HighAvailability")]
    HighAvailability,

    [Description("OperationalExcellence")]
    OperationalExcellence,

    [Description("Performance")]
    Performance,

    [Description("Security")]
    Security,
}
