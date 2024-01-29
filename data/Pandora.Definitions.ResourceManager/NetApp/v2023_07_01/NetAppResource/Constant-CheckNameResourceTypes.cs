// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.NetAppResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CheckNameResourceTypesConstant
{
    [Description("Microsoft.NetApp/netAppAccounts")]
    MicrosoftPointNetAppNetAppAccounts,

    [Description("Microsoft.NetApp/netAppAccounts/capacityPools")]
    MicrosoftPointNetAppNetAppAccountsCapacityPools,

    [Description("Microsoft.NetApp/netAppAccounts/capacityPools/volumes")]
    MicrosoftPointNetAppNetAppAccountsCapacityPoolsVolumes,

    [Description("Microsoft.NetApp/netAppAccounts/capacityPools/volumes/snapshots")]
    MicrosoftPointNetAppNetAppAccountsCapacityPoolsVolumesSnapshots,
}
