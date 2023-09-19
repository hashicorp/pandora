// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.Me;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GetMeMailTipRequestMailTipsOptionsConstant
{
    [Description("AutomaticReplies")]
    @automaticReplies,

    [Description("MailboxFullStatus")]
    @mailboxFullStatus,

    [Description("CustomMailTip")]
    @customMailTip,

    [Description("ExternalMemberCount")]
    @externalMemberCount,

    [Description("TotalMemberCount")]
    @totalMemberCount,

    [Description("MaxMessageSize")]
    @maxMessageSize,

    [Description("DeliveryRestriction")]
    @deliveryRestriction,

    [Description("ModerationStatus")]
    @moderationStatus,

    [Description("RecipientScope")]
    @recipientScope,

    [Description("RecipientSuggestions")]
    @recipientSuggestions,
}
