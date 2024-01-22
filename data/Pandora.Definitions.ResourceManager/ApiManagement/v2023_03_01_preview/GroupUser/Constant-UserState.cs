// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.GroupUser;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserStateConstant
{
    [Description("active")]
    Active,

    [Description("blocked")]
    Blocked,

    [Description("deleted")]
    Deleted,

    [Description("pending")]
    Pending,
}
