// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessPackageResourceRequestStateConstant
{
    [Description("Submitted")]
    @submitted,

    [Description("PendingApproval")]
    @pendingApproval,

    [Description("Delivering")]
    @delivering,

    [Description("Delivered")]
    @delivered,

    [Description("DeliveryFailed")]
    @deliveryFailed,

    [Description("Denied")]
    @denied,

    [Description("Scheduled")]
    @scheduled,

    [Description("Canceled")]
    @canceled,

    [Description("PartiallyDelivered")]
    @partiallyDelivered,
}
