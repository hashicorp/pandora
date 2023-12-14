// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BookingStaffMemberRoleConstant
{
    [Description("Guest")]
    @guest,

    [Description("Administrator")]
    @administrator,

    [Description("Viewer")]
    @viewer,

    [Description("ExternalGuest")]
    @externalGuest,

    [Description("Scheduler")]
    @scheduler,

    [Description("TeamMember")]
    @teamMember,
}
