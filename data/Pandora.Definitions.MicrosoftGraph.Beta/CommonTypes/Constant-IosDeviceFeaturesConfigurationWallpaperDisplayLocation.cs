// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosDeviceFeaturesConfigurationWallpaperDisplayLocationConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("LockScreen")]
    @lockScreen,

    [Description("HomeScreen")]
    @homeScreen,

    [Description("LockAndHomeScreens")]
    @lockAndHomeScreens,
}
