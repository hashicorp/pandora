// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsManagedDeviceProcessorArchitectureConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("X86")]
    @x86,

    [Description("X64")]
    @x64,

    [Description("Arm")]
    @arm,

    [Description("ArM64")]
    @arM64,
}
