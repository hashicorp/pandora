// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataDog.v2023_01_01.MonitorsResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MarketplaceSubscriptionStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Provisioning")]
    Provisioning,

    [Description("Suspended")]
    Suspended,

    [Description("Unsubscribed")]
    Unsubscribed,
}
