// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidDeviceOwnerGeneralDeviceConfigurationMicrosoftLauncherSearchBarPlacementConfigurationConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Top")]
    @top,

    [Description("Bottom")]
    @bottom,

    [Description("Hide")]
    @hide,
}
