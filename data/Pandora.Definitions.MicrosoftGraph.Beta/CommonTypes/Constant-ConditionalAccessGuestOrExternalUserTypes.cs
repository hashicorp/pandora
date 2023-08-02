// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionalAccessGuestOrExternalUserTypesConstant
{
    [Description("None")]
    @none,

    [Description("InternalGuest")]
    @internalGuest,

    [Description("B2bCollaborationGuest")]
    @b2bCollaborationGuest,

    [Description("B2bCollaborationMember")]
    @b2bCollaborationMember,

    [Description("B2bDirectConnectUser")]
    @b2bDirectConnectUser,

    [Description("OtherExternalUser")]
    @otherExternalUser,

    [Description("ServiceProvider")]
    @serviceProvider,
}
