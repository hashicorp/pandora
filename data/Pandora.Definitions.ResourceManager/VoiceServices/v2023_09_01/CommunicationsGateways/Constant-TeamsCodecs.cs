// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_09_01.CommunicationsGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TeamsCodecsConstant
{
    [Description("G722")]
    GSevenTwoTwo,

    [Description("G722_2")]
    GSevenTwoTwoTwo,

    [Description("PCMA")]
    PCMA,

    [Description("PCMU")]
    PCMU,

    [Description("SILK_8")]
    SILKEight,

    [Description("SILK_16")]
    SILKOneSix,
}
