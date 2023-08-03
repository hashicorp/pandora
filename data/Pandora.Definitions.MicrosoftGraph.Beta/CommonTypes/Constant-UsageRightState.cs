// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UsageRightStateConstant
{
    [Description("Active")]
    @active,

    [Description("Inactive")]
    @inactive,

    [Description("Warning")]
    @warning,

    [Description("Suspended")]
    @suspended,
}
