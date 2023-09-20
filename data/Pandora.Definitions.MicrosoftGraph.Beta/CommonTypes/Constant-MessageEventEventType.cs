// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MessageEventEventTypeConstant
{
    [Description("Received")]
    @received,

    [Description("Sent")]
    @sent,

    [Description("Delivered")]
    @delivered,

    [Description("Failed")]
    @failed,

    [Description("ProcessingFailed")]
    @processingFailed,

    [Description("DistributionGroupExpanded")]
    @distributionGroupExpanded,

    [Description("Submitted")]
    @submitted,

    [Description("Delayed")]
    @delayed,

    [Description("Redirected")]
    @redirected,

    [Description("Resolved")]
    @resolved,

    [Description("Dropped")]
    @dropped,

    [Description("RecipientsAdded")]
    @recipientsAdded,

    [Description("MalwareDetected")]
    @malwareDetected,

    [Description("MalwareDetectedInMessage")]
    @malwareDetectedInMessage,

    [Description("MalwareDetectedInAttachment")]
    @malwareDetectedInAttachment,

    [Description("TtZapped")]
    @ttZapped,

    [Description("TtDelivered")]
    @ttDelivered,

    [Description("SpamDetected")]
    @spamDetected,

    [Description("TransportRuleTriggered")]
    @transportRuleTriggered,

    [Description("DlpRuleTriggered")]
    @dlpRuleTriggered,

    [Description("Journaled")]
    @journaled,
}
