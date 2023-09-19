// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10GeneralConfigurationEdgeOpensWithConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("StartPage")]
    @startPage,

    [Description("NewTabPage")]
    @newTabPage,

    [Description("PreviousPages")]
    @previousPages,

    [Description("SpecificPages")]
    @specificPages,
}
