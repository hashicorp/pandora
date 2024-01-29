// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.JobTargetGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobTargetGroupMembershipTypeConstant
{
    [Description("Exclude")]
    Exclude,

    [Description("Include")]
    Include,
}
