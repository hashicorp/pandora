// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosGeneralDeviceConfigurationSafariCookieSettingsConstant
{
    [Description("BrowserDefault")]
    @browserDefault,

    [Description("BlockAlways")]
    @blockAlways,

    [Description("AllowCurrentWebSite")]
    @allowCurrentWebSite,

    [Description("AllowFromWebsitesVisited")]
    @allowFromWebsitesVisited,

    [Description("AllowAlways")]
    @allowAlways,
}
