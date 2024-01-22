// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.ManagedNetwork;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RuleStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Inactive")]
    Inactive,
}
