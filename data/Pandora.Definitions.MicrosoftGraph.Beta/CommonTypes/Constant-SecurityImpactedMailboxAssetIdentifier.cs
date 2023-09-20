// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityImpactedMailboxAssetIdentifierConstant
{
    [Description("AccountUpn")]
    @accountUpn,

    [Description("FileOwnerUpn")]
    @fileOwnerUpn,

    [Description("InitiatingProcessAccountUpn")]
    @initiatingProcessAccountUpn,

    [Description("LastModifyingAccountUpn")]
    @lastModifyingAccountUpn,

    [Description("TargetAccountUpn")]
    @targetAccountUpn,

    [Description("SenderFromAddress")]
    @senderFromAddress,

    [Description("SenderDisplayName")]
    @senderDisplayName,

    [Description("RecipientEmailAddress")]
    @recipientEmailAddress,

    [Description("SenderMailFromAddress")]
    @senderMailFromAddress,
}
