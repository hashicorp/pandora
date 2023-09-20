// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.User;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GetUserByIdMailTipRequestMailTipsOptionsConstant
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
