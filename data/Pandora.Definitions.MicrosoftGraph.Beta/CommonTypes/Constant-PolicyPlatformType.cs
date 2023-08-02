// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

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

    [Description("AndroidWorkProfile")]
    @androidWorkProfile,

    [Description("Windows10XProfile")]
    @windows10XProfile,

    [Description("AndroidAOSP")]
    @androidAOSP,

    [Description("All")]
    @all,
}
