// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LocationConstraintItemLocationTypeConstant
{
    [Description("Default")]
    @default,

    [Description("ConferenceRoom")]
    @conferenceRoom,

    [Description("HomeAddress")]
    @homeAddress,

    [Description("BusinessAddress")]
    @businessAddress,

    [Description("GeoCoordinates")]
    @geoCoordinates,

    [Description("StreetAddress")]
    @streetAddress,

    [Description("Hotel")]
    @hotel,

    [Description("Restaurant")]
    @restaurant,

    [Description("LocalBusiness")]
    @localBusiness,

    [Description("PostalAddress")]
    @postalAddress,
}
