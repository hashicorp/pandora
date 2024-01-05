// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualEventRegistrationPredefinedQuestionLabelConstant
{
    [Description("Street")]
    @street,

    [Description("City")]
    @city,

    [Description("State")]
    @state,

    [Description("PostalCode")]
    @postalCode,

    [Description("CountryOrRegion")]
    @countryOrRegion,

    [Description("Industry")]
    @industry,

    [Description("JobTitle")]
    @jobTitle,

    [Description("Organization")]
    @organization,
}
