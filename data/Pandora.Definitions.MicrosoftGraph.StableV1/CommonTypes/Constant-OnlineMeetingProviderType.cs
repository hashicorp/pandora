// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OnlineMeetingProviderTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("SkypeForBusiness")]
    @skypeForBusiness,

    [Description("SkypeForConsumer")]
    @skypeForConsumer,

    [Description("TeamsForBusiness")]
    @teamsForBusiness,
}
