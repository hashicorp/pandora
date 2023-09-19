// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceEnrollmentPlatformRestrictionConfigurationPlatformTypeConstant
{
    [Description("AllPlatforms")]
    @allPlatforms,

    [Description("Ios")]
    @ios,

    [Description("Windows")]
    @windows,

    [Description("WindowsPhone")]
    @windowsPhone,

    [Description("Android")]
    @android,

    [Description("AndroidForWork")]
    @androidForWork,

    [Description("Mac")]
    @mac,

    [Description("Linux")]
    @linux,
}
