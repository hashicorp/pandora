// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BrowserSiteHistoryCompatibilityModeConstant
{
    [Description("Default")]
    @default,

    [Description("InternetExplorer8Enterprise")]
    @internetExplorer8Enterprise,

    [Description("InternetExplorer7Enterprise")]
    @internetExplorer7Enterprise,

    [Description("InternetExplorer11")]
    @internetExplorer11,

    [Description("InternetExplorer10")]
    @internetExplorer10,

    [Description("InternetExplorer9")]
    @internetExplorer9,

    [Description("InternetExplorer8")]
    @internetExplorer8,

    [Description("InternetExplorer7")]
    @internetExplorer7,

    [Description("InternetExplorer5")]
    @internetExplorer5,
}
