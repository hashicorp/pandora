// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.Assessments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImplementationEffortConstant
{
    [Description("High")]
    High,

    [Description("Low")]
    Low,

    [Description("Moderate")]
    Moderate,
}
