// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Policies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyEvaluatorTypeConstant
{
    [Description("AllowedValuesPolicy")]
    AllowedValuesPolicy,

    [Description("MaxValuePolicy")]
    MaxValuePolicy,
}
