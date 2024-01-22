// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceScalingTriggerKindConstant
{
    [Description("AveragePartitionLoadTrigger")]
    AveragePartitionLoadTrigger,

    [Description("AverageServiceLoadTrigger")]
    AverageServiceLoadTrigger,
}
