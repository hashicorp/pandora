// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AllowInvitesFromConstant
{
    [Description("None")]
    @none,

    [Description("AdminsAndGuestInviters")]
    @adminsAndGuestInviters,

    [Description("AdminsGuestInvitersAndAllMembers")]
    @adminsGuestInvitersAndAllMembers,

    [Description("Everyone")]
    @everyone,
}
