// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendationStatusConstant
{
    [Description("Active")]
    @active,

    [Description("CompletedBySystem")]
    @completedBySystem,

    [Description("CompletedByUser")]
    @completedByUser,

    [Description("Dismissed")]
    @dismissed,

    [Description("Postponed")]
    @postponed,
}
