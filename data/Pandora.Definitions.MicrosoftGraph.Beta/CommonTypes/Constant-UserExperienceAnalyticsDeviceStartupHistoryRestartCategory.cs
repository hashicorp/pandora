// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserExperienceAnalyticsDeviceStartupHistoryRestartCategoryConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("RestartWithUpdate")]
    @restartWithUpdate,

    [Description("RestartWithoutUpdate")]
    @restartWithoutUpdate,

    [Description("BlueScreen")]
    @blueScreen,

    [Description("ShutdownWithUpdate")]
    @shutdownWithUpdate,

    [Description("ShutdownWithoutUpdate")]
    @shutdownWithoutUpdate,

    [Description("LongPowerButtonPress")]
    @longPowerButtonPress,

    [Description("BootError")]
    @bootError,

    [Description("Update")]
    @update,
}
