// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecuritySubmissionResultDetailConstant
{
    [Description("None")]
    @none,

    [Description("UnderInvestigation")]
    @underInvestigation,

    [Description("SimulatedThreat")]
    @simulatedThreat,

    [Description("AllowedBySecOps")]
    @allowedBySecOps,

    [Description("AllowedByThirdPartyFilters")]
    @allowedByThirdPartyFilters,

    [Description("MessageNotFound")]
    @messageNotFound,

    [Description("UrlFileShouldNotBeBlocked")]
    @urlFileShouldNotBeBlocked,

    [Description("UrlFileShouldBeBlocked")]
    @urlFileShouldBeBlocked,

    [Description("UrlFileCannotMakeDecision")]
    @urlFileCannotMakeDecision,

    [Description("DomainImpersonation")]
    @domainImpersonation,

    [Description("UserImpersonation")]
    @userImpersonation,

    [Description("BrandImpersonation")]
    @brandImpersonation,

    [Description("OutboundShouldNotBeBlocked")]
    @outboundShouldNotBeBlocked,

    [Description("OutboundShouldBeBlocked")]
    @outboundShouldBeBlocked,

    [Description("OutboundBulk")]
    @outboundBulk,

    [Description("OutboundCannotMakeDecision")]
    @outboundCannotMakeDecision,

    [Description("OutboundNotRescanned")]
    @outboundNotRescanned,

    [Description("ZeroHourAutoPurgeAllowed")]
    @zeroHourAutoPurgeAllowed,

    [Description("ZeroHourAutoPurgeBlocked")]
    @zeroHourAutoPurgeBlocked,

    [Description("ZeroHourAutoPurgeQuarantineReleased")]
    @zeroHourAutoPurgeQuarantineReleased,

    [Description("OnPremisesSkip")]
    @onPremisesSkip,

    [Description("AllowedByTenantAllowBlockList")]
    @allowedByTenantAllowBlockList,

    [Description("BlockedByTenantAllowBlockList")]
    @blockedByTenantAllowBlockList,

    [Description("AllowedUrlByTenantAllowBlockList")]
    @allowedUrlByTenantAllowBlockList,

    [Description("AllowedFileByTenantAllowBlockList")]
    @allowedFileByTenantAllowBlockList,

    [Description("AllowedSenderByTenantAllowBlockList")]
    @allowedSenderByTenantAllowBlockList,

    [Description("AllowedRecipientByTenantAllowBlockList")]
    @allowedRecipientByTenantAllowBlockList,

    [Description("BlockedUrlByTenantAllowBlockList")]
    @blockedUrlByTenantAllowBlockList,

    [Description("BlockedFileByTenantAllowBlockList")]
    @blockedFileByTenantAllowBlockList,

    [Description("BlockedSenderByTenantAllowBlockList")]
    @blockedSenderByTenantAllowBlockList,

    [Description("BlockedRecipientByTenantAllowBlockList")]
    @blockedRecipientByTenantAllowBlockList,

    [Description("AllowedByConnection")]
    @allowedByConnection,

    [Description("BlockedByConnection")]
    @blockedByConnection,

    [Description("AllowedByExchangeTransportRule")]
    @allowedByExchangeTransportRule,

    [Description("BlockedByExchangeTransportRule")]
    @blockedByExchangeTransportRule,

    [Description("QuarantineReleased")]
    @quarantineReleased,

    [Description("QuarantineReleasedThenBlocked")]
    @quarantineReleasedThenBlocked,

    [Description("JunkMailRuleDisabled")]
    @junkMailRuleDisabled,

    [Description("AllowedByUserSetting")]
    @allowedByUserSetting,

    [Description("BlockedByUserSetting")]
    @blockedByUserSetting,

    [Description("AllowedByTenant")]
    @allowedByTenant,

    [Description("BlockedByTenant")]
    @blockedByTenant,

    [Description("InvalidFalsePositive")]
    @invalidFalsePositive,

    [Description("InvalidFalseNegative")]
    @invalidFalseNegative,

    [Description("SpoofBlocked")]
    @spoofBlocked,

    [Description("GoodReclassifiedAsBad")]
    @goodReclassifiedAsBad,

    [Description("GoodReclassifiedAsBulk")]
    @goodReclassifiedAsBulk,

    [Description("GoodReclassifiedAsGood")]
    @goodReclassifiedAsGood,

    [Description("GoodReclassifiedAsCannotMakeDecision")]
    @goodReclassifiedAsCannotMakeDecision,

    [Description("BadReclassifiedAsGood")]
    @badReclassifiedAsGood,

    [Description("BadReclassifiedAsBulk")]
    @badReclassifiedAsBulk,

    [Description("BadReclassifiedAsBad")]
    @badReclassifiedAsBad,

    [Description("BadReclassifiedAsCannotMakeDecision")]
    @badReclassifiedAsCannotMakeDecision,
}
