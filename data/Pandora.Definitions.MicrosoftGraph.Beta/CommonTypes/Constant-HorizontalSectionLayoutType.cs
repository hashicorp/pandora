// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HorizontalSectionLayoutTypeConstant
{
    [Description("None")]
    @none,

    [Description("OneColumn")]
    @oneColumn,

    [Description("TwoColumns")]
    @twoColumns,

    [Description("ThreeColumns")]
    @threeColumns,

    [Description("OneThirdLeftColumn")]
    @oneThirdLeftColumn,

    [Description("OneThirdRightColumn")]
    @oneThirdRightColumn,

    [Description("FullWidth")]
    @fullWidth,
}
