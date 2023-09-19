// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ComanagementEligibleDeviceStatusConstant
{
    [Description("Comanaged")]
    @comanaged,

    [Description("Eligible")]
    @eligible,

    [Description("EligibleButNotAzureAdJoined")]
    @eligibleButNotAzureAdJoined,

    [Description("NeedsOsUpdate")]
    @needsOsUpdate,

    [Description("Ineligible")]
    @ineligible,

    [Description("ScheduledForEnrollment")]
    @scheduledForEnrollment,
}
