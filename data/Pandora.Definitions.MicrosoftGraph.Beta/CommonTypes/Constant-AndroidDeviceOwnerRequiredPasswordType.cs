// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidDeviceOwnerRequiredPasswordTypeConstant
{
    [Description("DeviceDefault")]
    @deviceDefault,

    [Description("Required")]
    @required,

    [Description("Numeric")]
    @numeric,

    [Description("NumericComplex")]
    @numericComplex,

    [Description("Alphabetic")]
    @alphabetic,

    [Description("Alphanumeric")]
    @alphanumeric,

    [Description("AlphanumericWithSymbols")]
    @alphanumericWithSymbols,

    [Description("LowSecurityBiometric")]
    @lowSecurityBiometric,

    [Description("CustomPassword")]
    @customPassword,
}
