// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OnPremisesPublishingTypeConstant
{
    [Description("ApplicationProxy")]
    @applicationProxy,

    [Description("ExchangeOnline")]
    @exchangeOnline,

    [Description("Authentication")]
    @authentication,

    [Description("Provisioning")]
    @provisioning,

    [Description("IntunePfx")]
    @intunePfx,

    [Description("OflineDomainJoin")]
    @oflineDomainJoin,
}
