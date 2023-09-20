// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PhoneAuthenticationMethodSmsSignInStateConstant
{
    [Description("NotSupported")]
    @notSupported,

    [Description("NotAllowedByPolicy")]
    @notAllowedByPolicy,

    [Description("NotEnabled")]
    @notEnabled,

    [Description("PhoneNumberNotUnique")]
    @phoneNumberNotUnique,

    [Description("Ready")]
    @ready,

    [Description("NotConfigured")]
    @notConfigured,
}
