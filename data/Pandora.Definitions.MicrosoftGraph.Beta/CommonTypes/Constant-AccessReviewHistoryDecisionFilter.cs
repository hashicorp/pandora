// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessReviewHistoryDecisionFilterConstant
{
    [Description("Approve")]
    @approve,

    [Description("Deny")]
    @deny,

    [Description("NotReviewed")]
    @notReviewed,

    [Description("DontKnow")]
    @dontKnow,

    [Description("NotNotified")]
    @notNotified,
}
