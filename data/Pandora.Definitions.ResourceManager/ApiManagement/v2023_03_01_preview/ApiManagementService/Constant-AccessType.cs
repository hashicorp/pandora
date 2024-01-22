// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiManagementService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessTypeConstant
{
    [Description("AccessKey")]
    AccessKey,

    [Description("SystemAssignedManagedIdentity")]
    SystemAssignedManagedIdentity,

    [Description("UserAssignedManagedIdentity")]
    UserAssignedManagedIdentity,
}
