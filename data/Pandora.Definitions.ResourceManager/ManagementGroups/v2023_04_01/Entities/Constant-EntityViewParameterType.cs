// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2023_04_01.Entities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EntityViewParameterTypeConstant
{
    [Description("Audit")]
    Audit,

    [Description("FullHierarchy")]
    FullHierarchy,

    [Description("GroupsOnly")]
    GroupsOnly,

    [Description("SubscriptionsOnly")]
    SubscriptionsOnly,
}
