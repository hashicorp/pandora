// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkforceIntegrationSupportedEntitiesConstant
{
    [Description("None")]
    @none,

    [Description("Shift")]
    @shift,

    [Description("SwapRequest")]
    @swapRequest,

    [Description("UserShiftPreferences")]
    @userShiftPreferences,

    [Description("OpenShift")]
    @openShift,

    [Description("OpenShiftRequest")]
    @openShiftRequest,

    [Description("OfferShiftRequest")]
    @offerShiftRequest,
}
