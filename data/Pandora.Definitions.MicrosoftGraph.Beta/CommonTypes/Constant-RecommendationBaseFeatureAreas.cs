// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendationBaseFeatureAreasConstant
{
    [Description("Users")]
    @users,

    [Description("Groups")]
    @groups,

    [Description("Devices")]
    @devices,

    [Description("Applications")]
    @applications,

    [Description("AccessReviews")]
    @accessReviews,

    [Description("ConditionalAccess")]
    @conditionalAccess,

    [Description("Governance")]
    @governance,
}
