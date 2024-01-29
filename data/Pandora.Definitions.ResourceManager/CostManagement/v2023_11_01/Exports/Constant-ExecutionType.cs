// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_11_01.Exports;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExecutionTypeConstant
{
    [Description("OnDemand")]
    OnDemand,

    [Description("Scheduled")]
    Scheduled,
}
