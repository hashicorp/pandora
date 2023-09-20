// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UnifiedRoleManagementPolicyRuleTargetOperationsConstant
{
    [Description("All")]
    @all,

    [Description("Activate")]
    @activate,

    [Description("Deactivate")]
    @deactivate,

    [Description("Assign")]
    @assign,

    [Description("Update")]
    @update,

    [Description("Remove")]
    @remove,

    [Description("Extend")]
    @extend,

    [Description("Renew")]
    @renew,
}
