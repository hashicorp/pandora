// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LocalSecurityOptionsAdministratorElevationPromptBehaviorTypeConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("ElevateWithoutPrompting")]
    @elevateWithoutPrompting,

    [Description("PromptForCredentialsOnTheSecureDesktop")]
    @promptForCredentialsOnTheSecureDesktop,

    [Description("PromptForConsentOnTheSecureDesktop")]
    @promptForConsentOnTheSecureDesktop,

    [Description("PromptForCredentials")]
    @promptForCredentials,

    [Description("PromptForConsent")]
    @promptForConsent,

    [Description("PromptForConsentForNonWindowsBinaries")]
    @promptForConsentForNonWindowsBinaries,
}
