// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterSkuNameEnumConstant
{
    [Description("CapacityReservation")]
    CapacityReservation,
}
