// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AclTypeConstant
{
    [Description("User")]
    @user,

    [Description("Group")]
    @group,

    [Description("Everyone")]
    @everyone,

    [Description("EveryoneExceptGuests")]
    @everyoneExceptGuests,

    [Description("ExternalGroup")]
    @externalGroup,
}
