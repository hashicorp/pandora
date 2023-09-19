// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementConfigurationPolicyPlatformsConstant
{
    [Description("None")]
    @none,

    [Description("Android")]
    @android,

    [Description("IOS")]
    @iOS,

    [Description("MacOS")]
    @macOS,

    [Description("Windows10X")]
    @windows10X,

    [Description("Windows10")]
    @windows10,

    [Description("Linux")]
    @linux,
}
