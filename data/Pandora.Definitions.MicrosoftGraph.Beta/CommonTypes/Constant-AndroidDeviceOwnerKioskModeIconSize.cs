// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidDeviceOwnerKioskModeIconSizeConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Smallest")]
    @smallest,

    [Description("Small")]
    @small,

    [Description("Regular")]
    @regular,

    [Description("Large")]
    @large,

    [Description("Largest")]
    @largest,
}
