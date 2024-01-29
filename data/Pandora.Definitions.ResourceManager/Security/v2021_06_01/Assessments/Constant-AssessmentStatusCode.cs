// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.Assessments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssessmentStatusCodeConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("NotApplicable")]
    NotApplicable,

    [Description("Unhealthy")]
    Unhealthy,
}
