// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BookingAppointmentPriceTypeConstant
{
    [Description("Undefined")]
    @undefined,

    [Description("FixedPrice")]
    @fixedPrice,

    [Description("StartingAt")]
    @startingAt,

    [Description("Hourly")]
    @hourly,

    [Description("Free")]
    @free,

    [Description("PriceVaries")]
    @priceVaries,

    [Description("CallUs")]
    @callUs,

    [Description("NotSet")]
    @notSet,
}
