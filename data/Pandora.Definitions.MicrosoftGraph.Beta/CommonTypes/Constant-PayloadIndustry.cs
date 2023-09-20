// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PayloadIndustryConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Other")]
    @other,

    [Description("Banking")]
    @banking,

    [Description("BusinessServices")]
    @businessServices,

    [Description("ConsumerServices")]
    @consumerServices,

    [Description("Education")]
    @education,

    [Description("Energy")]
    @energy,

    [Description("Construction")]
    @construction,

    [Description("Consulting")]
    @consulting,

    [Description("FinancialServices")]
    @financialServices,

    [Description("Government")]
    @government,

    [Description("Hospitality")]
    @hospitality,

    [Description("Insurance")]
    @insurance,

    [Description("Legal")]
    @legal,

    [Description("CourierServices")]
    @courierServices,

    [Description("IT")]
    @IT,

    [Description("Healthcare")]
    @healthcare,

    [Description("Manufacturing")]
    @manufacturing,

    [Description("Retail")]
    @retail,

    [Description("Telecom")]
    @telecom,

    [Description("RealEstate")]
    @realEstate,
}
