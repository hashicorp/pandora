// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TeamworkApplicationIdentityTypeConstant
{
    [Description("AadApplication")]
    @aadApplication,

    [Description("Bot")]
    @bot,

    [Description("TenantBot")]
    @tenantBot,

    [Description("Office365Connector")]
    @office365Connector,

    [Description("OutgoingWebhook")]
    @outgoingWebhook,
}
