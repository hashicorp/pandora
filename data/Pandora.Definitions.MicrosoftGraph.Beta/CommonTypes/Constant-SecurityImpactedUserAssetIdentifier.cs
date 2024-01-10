// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityImpactedUserAssetIdentifierConstant
{
    [Description("AccountObjectId")]
    @accountObjectId,

    [Description("AccountSid")]
    @accountSid,

    [Description("AccountUpn")]
    @accountUpn,

    [Description("AccountName")]
    @accountName,

    [Description("AccountDomain")]
    @accountDomain,

    [Description("AccountId")]
    @accountId,

    [Description("RequestAccountSid")]
    @requestAccountSid,

    [Description("RequestAccountName")]
    @requestAccountName,

    [Description("RequestAccountDomain")]
    @requestAccountDomain,

    [Description("RecipientObjectId")]
    @recipientObjectId,

    [Description("ProcessAccountObjectId")]
    @processAccountObjectId,

    [Description("InitiatingAccountSid")]
    @initiatingAccountSid,

    [Description("InitiatingProcessAccountUpn")]
    @initiatingProcessAccountUpn,

    [Description("InitiatingAccountName")]
    @initiatingAccountName,

    [Description("InitiatingAccountDomain")]
    @initiatingAccountDomain,

    [Description("ServicePrincipalId")]
    @servicePrincipalId,

    [Description("ServicePrincipalName")]
    @servicePrincipalName,

    [Description("TargetAccountUpn")]
    @targetAccountUpn,
}
