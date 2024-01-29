// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2023_04_01.ManagementGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagementGroupChildTypeConstant
{
    [Description("Microsoft.Management/managementGroups")]
    MicrosoftPointManagementManagementGroups,

    [Description("/subscriptions")]
    Subscriptions,
}
