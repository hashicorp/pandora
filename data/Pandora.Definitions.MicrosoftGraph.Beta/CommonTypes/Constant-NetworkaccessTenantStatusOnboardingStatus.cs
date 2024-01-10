// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessTenantStatusOnboardingStatusConstant
{
    [Description("Offboarded")]
    @offboarded,

    [Description("OffboardingInProgress")]
    @offboardingInProgress,

    [Description("OnboardingInProgress")]
    @onboardingInProgress,

    [Description("Onboarded")]
    @onboarded,

    [Description("OnboardingErrorOccurred")]
    @onboardingErrorOccurred,

    [Description("OffboardingErrorOccurred")]
    @offboardingErrorOccurred,
}
