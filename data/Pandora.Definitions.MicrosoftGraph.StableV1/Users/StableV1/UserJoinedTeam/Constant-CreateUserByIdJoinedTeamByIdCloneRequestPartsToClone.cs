// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeam;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateUserByIdJoinedTeamByIdCloneRequestPartsToCloneConstant
{
    [Description("Apps")]
    @apps,

    [Description("Tabs")]
    @tabs,

    [Description("Settings")]
    @settings,

    [Description("Channels")]
    @channels,

    [Description("Members")]
    @members,
}
