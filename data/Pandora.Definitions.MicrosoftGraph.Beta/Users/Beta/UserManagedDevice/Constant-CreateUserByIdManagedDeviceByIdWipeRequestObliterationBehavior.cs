// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDevice;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateUserByIdManagedDeviceByIdWipeRequestObliterationBehaviorConstant
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
