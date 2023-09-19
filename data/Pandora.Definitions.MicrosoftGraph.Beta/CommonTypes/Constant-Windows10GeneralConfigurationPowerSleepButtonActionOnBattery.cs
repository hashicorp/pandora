// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10GeneralConfigurationPowerSleepButtonActionOnBatteryConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("NoAction")]
    @noAction,

    [Description("Sleep")]
    @sleep,

    [Description("Hibernate")]
    @hibernate,

    [Description("Shutdown")]
    @shutdown,
}
