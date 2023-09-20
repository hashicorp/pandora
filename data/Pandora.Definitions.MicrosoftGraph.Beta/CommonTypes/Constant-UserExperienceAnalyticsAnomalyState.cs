// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserExperienceAnalyticsAnomalyStateConstant
{
    [Description("New")]
    @new,

    [Description("Active")]
    @active,

    [Description("Disabled")]
    @disabled,

    [Description("Removed")]
    @removed,

    [Description("Other")]
    @other,
}
