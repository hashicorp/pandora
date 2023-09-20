// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosNotificationSettingsAlertTypeConstant
{
    [Description("DeviceDefault")]
    @deviceDefault,

    [Description("Banner")]
    @banner,

    [Description("Modal")]
    @modal,

    [Description("None")]
    @none,
}
