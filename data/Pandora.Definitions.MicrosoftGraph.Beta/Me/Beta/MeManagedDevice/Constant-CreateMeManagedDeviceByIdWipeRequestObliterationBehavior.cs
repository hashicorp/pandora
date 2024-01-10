// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDevice;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateMeManagedDeviceByIdWipeRequestObliterationBehaviorConstant
{
    [Description("Default")]
    @default,

    [Description("DoNotObliterate")]
    @doNotObliterate,

    [Description("ObliterateWithWarning")]
    @obliterateWithWarning,

    [Description("Always")]
    @always,
}
