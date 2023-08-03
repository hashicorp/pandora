// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegistryValueTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Binary")]
    @binary,

    [Description("Dword")]
    @dword,

    [Description("DwordLittleEndian")]
    @dwordLittleEndian,

    [Description("DwordBigEndian")]
    @dwordBigEndian,

    [Description("ExpandSz")]
    @expandSz,

    [Description("Link")]
    @link,

    [Description("MultiSz")]
    @multiSz,

    [Description("None")]
    @none,

    [Description("Qword")]
    @qword,

    [Description("QwordlittleEndian")]
    @qwordlittleEndian,

    [Description("Sz")]
    @sz,
}
