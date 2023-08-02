// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyPlatformTypeConstant
{
    [Description("Android")]
    @android,

    [Description("AndroidForWork")]
    @androidForWork,

    [Description("IOS")]
    @iOS,

    [Description("MacOS")]
    @macOS,

    [Description("WindowsPhone81")]
    @windowsPhone81,

    [Description("Windows81AndLater")]
    @windows81AndLater,

    [Description("Windows10AndLater")]
    @windows10AndLater,

    [Description("All")]
    @all,
}
