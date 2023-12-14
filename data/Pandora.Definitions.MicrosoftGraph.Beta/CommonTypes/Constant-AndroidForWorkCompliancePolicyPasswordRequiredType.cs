// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidForWorkCompliancePolicyPasswordRequiredTypeConstant
{
    [Description("DeviceDefault")]
    @deviceDefault,

    [Description("Alphabetic")]
    @alphabetic,

    [Description("Alphanumeric")]
    @alphanumeric,

    [Description("AlphanumericWithSymbols")]
    @alphanumericWithSymbols,

    [Description("LowSecurityBiometric")]
    @lowSecurityBiometric,

    [Description("Numeric")]
    @numeric,

    [Description("NumericComplex")]
    @numericComplex,

    [Description("Any")]
    @any,
}
