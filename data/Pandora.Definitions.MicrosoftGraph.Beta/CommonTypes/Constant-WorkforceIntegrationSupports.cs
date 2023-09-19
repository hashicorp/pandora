// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkforceIntegrationSupportsConstant
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

    [Description("TimeCard")]
    @timeCard,

    [Description("TimeOffReason")]
    @timeOffReason,

    [Description("TimeOff")]
    @timeOff,

    [Description("TimeOffRequest")]
    @timeOffRequest,
}
