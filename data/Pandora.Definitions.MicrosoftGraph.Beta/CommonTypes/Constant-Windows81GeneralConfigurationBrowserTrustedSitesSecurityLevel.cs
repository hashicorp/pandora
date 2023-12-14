// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows81GeneralConfigurationBrowserTrustedSitesSecurityLevelConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("Low")]
    @low,

    [Description("MediumLow")]
    @mediumLow,

    [Description("Medium")]
    @medium,

    [Description("MediumHigh")]
    @mediumHigh,

    [Description("High")]
    @high,
}
