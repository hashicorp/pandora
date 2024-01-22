// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.SubAssessments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SubAssessmentStatusCodeConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("NotApplicable")]
    NotApplicable,

    [Description("Unhealthy")]
    Unhealthy,
}
