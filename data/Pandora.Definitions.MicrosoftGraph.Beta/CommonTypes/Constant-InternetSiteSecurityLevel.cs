// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InternetSiteSecurityLevelConstant
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
