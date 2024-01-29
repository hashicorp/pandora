// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.VirtualWANs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IkeIntegrityConstant
{
    [Description("GCMAES128")]
    GCMAESOneTwoEight,

    [Description("GCMAES256")]
    GCMAESTwoFiveSix,

    [Description("MD5")]
    MDFive,

    [Description("SHA1")]
    SHAOne,

    [Description("SHA384")]
    SHAThreeEightFour,

    [Description("SHA256")]
    SHATwoFiveSix,
}
