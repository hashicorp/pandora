// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OnboardingStatusConstant
{
    [Description("InsufficientInfo")]
    @insufficientInfo,

    [Description("Onboarded")]
    @onboarded,

    [Description("CanBeOnboarded")]
    @canBeOnboarded,

    [Description("Unsupported")]
    @unsupported,
}
