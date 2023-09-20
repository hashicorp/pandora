// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PlannerPlanContextDetailsDisplayLinkTypeConstant
{
    [Description("TeamsTab")]
    @teamsTab,

    [Description("SharePointPage")]
    @sharePointPage,

    [Description("MeetingNotes")]
    @meetingNotes,

    [Description("Other")]
    @other,

    [Description("LoopPage")]
    @loopPage,

    [Description("Project")]
    @project,
}
