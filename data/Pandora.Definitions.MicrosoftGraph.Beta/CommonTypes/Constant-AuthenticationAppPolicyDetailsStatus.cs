// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationAppPolicyDetailsStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("AppLockOutOfDate")]
    @appLockOutOfDate,

    [Description("AppLockEnabled")]
    @appLockEnabled,

    [Description("AppLockDisabled")]
    @appLockDisabled,

    [Description("AppContextOutOfDate")]
    @appContextOutOfDate,

    [Description("AppContextShown")]
    @appContextShown,

    [Description("AppContextNotShown")]
    @appContextNotShown,

    [Description("LocationContextOutOfDate")]
    @locationContextOutOfDate,

    [Description("LocationContextShown")]
    @locationContextShown,

    [Description("LocationContextNotShown")]
    @locationContextNotShown,

    [Description("NumberMatchOutOfDate")]
    @numberMatchOutOfDate,

    [Description("NumberMatchCorrectNumberEntered")]
    @numberMatchCorrectNumberEntered,

    [Description("NumberMatchIncorrectNumberEntered")]
    @numberMatchIncorrectNumberEntered,

    [Description("NumberMatchDeny")]
    @numberMatchDeny,

    [Description("TamperResistantHardwareOutOfDate")]
    @tamperResistantHardwareOutOfDate,

    [Description("TamperResistantHardwareUsed")]
    @tamperResistantHardwareUsed,

    [Description("TamperResistantHardwareNotUsed")]
    @tamperResistantHardwareNotUsed,
}
