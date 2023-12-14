// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImportedDeviceIdentityResultPlatformConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Ios")]
    @ios,

    [Description("Android")]
    @android,

    [Description("Windows")]
    @windows,

    [Description("WindowsMobile")]
    @windowsMobile,

    [Description("MacOS")]
    @macOS,
}
