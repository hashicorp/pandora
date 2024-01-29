// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2021_07_01.SubscriptionFeatureRegistrations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SubscriptionFeatureRegistrationApprovalTypeConstant
{
    [Description("ApprovalRequired")]
    ApprovalRequired,

    [Description("AutoApproval")]
    AutoApproval,

    [Description("NotSpecified")]
    NotSpecified,
}
