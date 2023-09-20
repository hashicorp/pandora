// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionalAccessConditionSetClientAppTypesConstant
{
    [Description("All")]
    @all,

    [Description("Browser")]
    @browser,

    [Description("MobileAppsAndDesktopClients")]
    @mobileAppsAndDesktopClients,

    [Description("ExchangeActiveSync")]
    @exchangeActiveSync,

    [Description("EasSupported")]
    @easSupported,

    [Description("Other")]
    @other,
}
