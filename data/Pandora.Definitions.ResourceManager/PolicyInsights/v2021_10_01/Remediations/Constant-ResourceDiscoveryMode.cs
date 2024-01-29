// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2021_10_01.Remediations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceDiscoveryModeConstant
{
    [Description("ExistingNonCompliant")]
    ExistingNonCompliant,

    [Description("ReEvaluateCompliance")]
    ReEvaluateCompliance,
}
