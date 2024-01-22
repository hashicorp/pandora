// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.FleetUpdateStrategies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FleetUpdateStrategyProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
