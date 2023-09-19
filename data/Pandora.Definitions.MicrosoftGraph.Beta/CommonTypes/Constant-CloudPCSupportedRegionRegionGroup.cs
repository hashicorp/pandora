// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCSupportedRegionRegionGroupConstant
{
    [Description("Default")]
    @default,

    [Description("Australia")]
    @australia,

    [Description("Canada")]
    @canada,

    [Description("UsCentral")]
    @usCentral,

    [Description("UsEast")]
    @usEast,

    [Description("UsWest")]
    @usWest,

    [Description("France")]
    @france,

    [Description("Germany")]
    @germany,

    [Description("EuropeUnion")]
    @europeUnion,

    [Description("UnitedKingdom")]
    @unitedKingdom,

    [Description("Japan")]
    @japan,

    [Description("Asia")]
    @asia,

    [Description("India")]
    @india,

    [Description("SouthAmerica")]
    @southAmerica,

    [Description("Euap")]
    @euap,

    [Description("UsGovernment")]
    @usGovernment,

    [Description("UsGovernmentDOD")]
    @usGovernmentDOD,

    [Description("Norway")]
    @norway,

    [Description("Switzerland")]
    @switzerland,

    [Description("SouthKorea")]
    @southKorea,
}
