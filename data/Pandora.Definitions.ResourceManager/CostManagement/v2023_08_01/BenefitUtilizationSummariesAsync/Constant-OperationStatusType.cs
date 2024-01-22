// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.BenefitUtilizationSummariesAsync;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationStatusTypeConstant
{
    [Description("Complete")]
    Complete,

    [Description("Failed")]
    Failed,

    [Description("Running")]
    Running,
}
