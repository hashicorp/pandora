// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InvitationRedemptionIdentityProviderConfigurationPrimaryIdentityProviderPrecedenceOrderConstant
{
    [Description("AzureActiveDirectory")]
    @azureActiveDirectory,

    [Description("ExternalFederation")]
    @externalFederation,

    [Description("SocialIdentityProviders")]
    @socialIdentityProviders,

    [Description("EmailOneTimePasscode")]
    @emailOneTimePasscode,

    [Description("MicrosoftAccount")]
    @microsoftAccount,

    [Description("DefaultConfiguredIdp")]
    @defaultConfiguredIdp,
}
