// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Win32LobAppReturnCodeTypeConstant
{
    [Description("Failed")]
    @failed,

    [Description("Success")]
    @success,

    [Description("SoftReboot")]
    @softReboot,

    [Description("HardReboot")]
    @hardReboot,

    [Description("Retry")]
    @retry,
}
