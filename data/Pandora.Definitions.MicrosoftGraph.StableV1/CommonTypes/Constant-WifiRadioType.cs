// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WifiRadioTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Wifi80211a")]
    @wifi80211a,

    [Description("Wifi80211b")]
    @wifi80211b,

    [Description("Wifi80211g")]
    @wifi80211g,

    [Description("Wifi80211n")]
    @wifi80211n,

    [Description("Wifi80211ac")]
    @wifi80211ac,

    [Description("Wifi80211ax")]
    @wifi80211ax,
}
