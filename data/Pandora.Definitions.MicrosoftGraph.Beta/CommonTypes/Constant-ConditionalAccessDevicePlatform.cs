// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionalAccessDevicePlatformConstant
{
    [Description("Android")]
    @android,

    [Description("IOS")]
    @iOS,

    [Description("Windows")]
    @windows,

    [Description("WindowsPhone")]
    @windowsPhone,

    [Description("MacOS")]
    @macOS,

    [Description("All")]
    @all,

    [Description("Linux")]
    @linux,
}
