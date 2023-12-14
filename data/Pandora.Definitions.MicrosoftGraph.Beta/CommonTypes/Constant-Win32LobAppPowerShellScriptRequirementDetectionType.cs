// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Win32LobAppPowerShellScriptRequirementDetectionTypeConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("String")]
    @string,

    [Description("DateTime")]
    @dateTime,

    [Description("Integer")]
    @integer,

    [Description("Float")]
    @float,

    [Description("Version")]
    @version,

    [Description("Boolean")]
    @boolean,
}
