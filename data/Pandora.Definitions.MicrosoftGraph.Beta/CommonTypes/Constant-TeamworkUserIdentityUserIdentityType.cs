// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TeamworkUserIdentityUserIdentityTypeConstant
{
    [Description("AadUser")]
    @aadUser,

    [Description("OnPremiseAadUser")]
    @onPremiseAadUser,

    [Description("AnonymousGuest")]
    @anonymousGuest,

    [Description("FederatedUser")]
    @federatedUser,

    [Description("PersonalMicrosoftAccountUser")]
    @personalMicrosoftAccountUser,

    [Description("SkypeUser")]
    @skypeUser,

    [Description("PhoneUser")]
    @phoneUser,

    [Description("EmailUser")]
    @emailUser,

    [Description("AzureCommunicationServicesUser")]
    @azureCommunicationServicesUser,
}
