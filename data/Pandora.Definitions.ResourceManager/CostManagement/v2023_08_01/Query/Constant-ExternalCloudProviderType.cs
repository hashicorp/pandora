// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.Query;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExternalCloudProviderTypeConstant
{
    [Description("externalBillingAccounts")]
    ExternalBillingAccounts,

    [Description("externalSubscriptions")]
    ExternalSubscriptions,
}
