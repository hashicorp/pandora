// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PartnerInformationCompanyTypeConstant
{
    [Description("MicrosoftSupport")]
    @microsoftSupport,

    [Description("SyndicatePartner")]
    @syndicatePartner,

    [Description("BreadthPartner")]
    @breadthPartner,

    [Description("BreadthPartnerDelegatedAdmin")]
    @breadthPartnerDelegatedAdmin,

    [Description("ResellerPartnerDelegatedAdmin")]
    @resellerPartnerDelegatedAdmin,

    [Description("ValueAddedResellerPartnerDelegatedAdmin")]
    @valueAddedResellerPartnerDelegatedAdmin,
}
