// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeam;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateMeJoinedTeamByIdCloneRequestPartsToCloneConstant
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
