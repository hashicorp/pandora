// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.QumuloStorage.v2022_10_12.FileSystems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MarketplaceSubscriptionStatusConstant
{
    [Description("PendingFulfillmentStart")]
    PendingFulfillmentStart,

    [Description("Subscribed")]
    Subscribed,

    [Description("Suspended")]
    Suspended,

    [Description("Unsubscribed")]
    Unsubscribed,
}
