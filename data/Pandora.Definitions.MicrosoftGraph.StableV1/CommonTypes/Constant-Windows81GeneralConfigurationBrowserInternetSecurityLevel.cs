// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows81GeneralConfigurationBrowserInternetSecurityLevelConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("Medium")]
    @medium,

    [Description("MediumHigh")]
    @mediumHigh,

    [Description("High")]
    @high,
}
