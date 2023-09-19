// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MailAssessmentRequestDestinationRoutingReasonConstant
{
    [Description("None")]
    @none,

    [Description("MailFlowRule")]
    @mailFlowRule,

    [Description("SafeSender")]
    @safeSender,

    [Description("BlockedSender")]
    @blockedSender,

    [Description("AdvancedSpamFiltering")]
    @advancedSpamFiltering,

    [Description("DomainAllowList")]
    @domainAllowList,

    [Description("DomainBlockList")]
    @domainBlockList,

    [Description("NotInAddressBook")]
    @notInAddressBook,

    [Description("FirstTimeSender")]
    @firstTimeSender,

    [Description("AutoPurgeToInbox")]
    @autoPurgeToInbox,

    [Description("AutoPurgeToJunk")]
    @autoPurgeToJunk,

    [Description("AutoPurgeToDeleted")]
    @autoPurgeToDeleted,

    [Description("Outbound")]
    @outbound,

    [Description("NotJunk")]
    @notJunk,

    [Description("Junk")]
    @junk,
}
