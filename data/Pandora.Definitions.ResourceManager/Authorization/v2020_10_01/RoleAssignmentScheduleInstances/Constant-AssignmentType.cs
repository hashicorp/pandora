// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleAssignmentScheduleInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssignmentTypeConstant
{
    [Description("Activated")]
    Activated,

    [Description("Assigned")]
    Assigned,
}
