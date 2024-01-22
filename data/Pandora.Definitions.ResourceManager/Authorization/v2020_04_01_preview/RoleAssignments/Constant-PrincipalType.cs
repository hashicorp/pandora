// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Authorization.v2020_04_01_preview.RoleAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrincipalTypeConstant
{
    [Description("ForeignGroup")]
    ForeignGroup,

    [Description("Group")]
    Group,

    [Description("ServicePrincipal")]
    ServicePrincipal,

    [Description("User")]
    User,
}
