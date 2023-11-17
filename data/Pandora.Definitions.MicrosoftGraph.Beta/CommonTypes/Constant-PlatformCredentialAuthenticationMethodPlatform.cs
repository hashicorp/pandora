// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PlatformCredentialAuthenticationMethodPlatformConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Windows")]
    @windows,

    [Description("MacOS")]
    @macOS,

    [Description("IOS")]
    @iOS,

    [Description("Android")]
    @android,

    [Description("Linux")]
    @linux,
}
