// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthorizationPolicyAllowInvitesFromConstant
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
