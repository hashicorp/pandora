// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationMethodFeatureConstant
{
    [Description("SsprRegistered")]
    @ssprRegistered,

    [Description("SsprEnabled")]
    @ssprEnabled,

    [Description("SsprCapable")]
    @ssprCapable,

    [Description("PasswordlessCapable")]
    @passwordlessCapable,

    [Description("MfaCapable")]
    @mfaCapable,
}
