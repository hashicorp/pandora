// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FileTypeConstant
{
    [Description("Dll")]
    Dll,

    [Description("Exe")]
    Exe,

    [Description("Executable")]
    Executable,

    [Description("Msi")]
    Msi,

    [Description("Script")]
    Script,

    [Description("Unknown")]
    Unknown,
}
