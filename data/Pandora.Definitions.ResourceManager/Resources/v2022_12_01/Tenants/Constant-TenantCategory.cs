// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2022_12_01.Tenants;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TenantCategoryConstant
{
    [Description("Home")]
    Home,

    [Description("ManagedBy")]
    ManagedBy,

    [Description("ProjectedBy")]
    ProjectedBy,
}
