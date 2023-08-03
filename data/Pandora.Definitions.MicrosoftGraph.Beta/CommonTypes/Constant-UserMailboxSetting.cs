// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserMailboxSettingConstant
{
    [Description("None")]
    @none,

    [Description("JunkMailDeletion")]
    @junkMailDeletion,

    [Description("IsFromAddressInAddressBook")]
    @isFromAddressInAddressBook,

    [Description("IsFromAddressInAddressSafeList")]
    @isFromAddressInAddressSafeList,

    [Description("IsFromAddressInAddressBlockList")]
    @isFromAddressInAddressBlockList,

    [Description("IsFromAddressInAddressImplicitSafeList")]
    @isFromAddressInAddressImplicitSafeList,

    [Description("IsFromAddressInAddressImplicitJunkList")]
    @isFromAddressInAddressImplicitJunkList,

    [Description("IsFromDomainInDomainSafeList")]
    @isFromDomainInDomainSafeList,

    [Description("IsFromDomainInDomainBlockList")]
    @isFromDomainInDomainBlockList,

    [Description("IsRecipientInRecipientSafeList")]
    @isRecipientInRecipientSafeList,

    [Description("CustomRule")]
    @customRule,

    [Description("JunkMailRule")]
    @junkMailRule,

    [Description("SenderPraPresent")]
    @senderPraPresent,

    [Description("FromFirstTimeSender")]
    @fromFirstTimeSender,

    [Description("Exclusive")]
    @exclusive,

    [Description("PriorSeenPass")]
    @priorSeenPass,

    [Description("SenderAuthenticationSucceeded")]
    @senderAuthenticationSucceeded,

    [Description("IsJunkMailRuleEnabled")]
    @isJunkMailRuleEnabled,
}
