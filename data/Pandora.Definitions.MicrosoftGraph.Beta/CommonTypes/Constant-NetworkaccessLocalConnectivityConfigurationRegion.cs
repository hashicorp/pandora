// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessLocalConnectivityConfigurationRegionConstant
{
    [Description("EastUS")]
    @eastUS,

    [Description("EastUS2")]
    @eastUS2,

    [Description("WestUS")]
    @westUS,

    [Description("WestUS2")]
    @westUS2,

    [Description("WestUS3")]
    @westUS3,

    [Description("CentralUS")]
    @centralUS,

    [Description("NorthCentralUS")]
    @northCentralUS,

    [Description("SouthCentralUS")]
    @southCentralUS,

    [Description("NorthEurope")]
    @northEurope,

    [Description("WestEurope")]
    @westEurope,

    [Description("FranceCentral")]
    @franceCentral,

    [Description("GermanyWestCentral")]
    @germanyWestCentral,

    [Description("SwitzerlandNorth")]
    @switzerlandNorth,

    [Description("UkSouth")]
    @ukSouth,

    [Description("CanadaEast")]
    @canadaEast,

    [Description("CanadaCentral")]
    @canadaCentral,

    [Description("SouthAfricaWest")]
    @southAfricaWest,

    [Description("SouthAfricaNorth")]
    @southAfricaNorth,

    [Description("UaeNorth")]
    @uaeNorth,
}
