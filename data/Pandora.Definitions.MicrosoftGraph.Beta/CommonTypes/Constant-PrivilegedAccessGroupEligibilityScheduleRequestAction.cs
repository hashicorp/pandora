// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivilegedAccessGroupEligibilityScheduleRequestActionConstant
{
    [Description("AdminAssign")]
    @adminAssign,

    [Description("AdminUpdate")]
    @adminUpdate,

    [Description("AdminRemove")]
    @adminRemove,

    [Description("SelfActivate")]
    @selfActivate,

    [Description("SelfDeactivate")]
    @selfDeactivate,

    [Description("AdminExtend")]
    @adminExtend,

    [Description("AdminRenew")]
    @adminRenew,

    [Description("SelfExtend")]
    @selfExtend,

    [Description("SelfRenew")]
    @selfRenew,
}
