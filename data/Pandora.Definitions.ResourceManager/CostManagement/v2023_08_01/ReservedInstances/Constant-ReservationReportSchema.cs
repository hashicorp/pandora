// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.ReservedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReservationReportSchemaConstant
{
    [Description("InstanceFlexibilityGroup")]
    InstanceFlexibilityGroup,

    [Description("InstanceFlexibilityRatio")]
    InstanceFlexibilityRatio,

    [Description("InstanceId")]
    InstanceId,

    [Description("Kind")]
    Kind,

    [Description("ReservationId")]
    ReservationId,

    [Description("ReservationOrderId")]
    ReservationOrderId,

    [Description("ReservedHours")]
    ReservedHours,

    [Description("SkuName")]
    SkuName,

    [Description("TotalReservedQuantity")]
    TotalReservedQuantity,

    [Description("UsageDate")]
    UsageDate,

    [Description("UsedHours")]
    UsedHours,
}
