// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessPackageAssignmentStateConstant
{
    [Description("Delivering")]
    @delivering,

    [Description("PartiallyDelivered")]
    @partiallyDelivered,

    [Description("Delivered")]
    @delivered,

    [Description("Expired")]
    @expired,

    [Description("DeliveryFailed")]
    @deliveryFailed,
}
