// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamScheduleDayNote;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamScheduleDayNote";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamScheduleDayNoteOperation(),
        new DeleteGroupByIdTeamScheduleDayNoteByIdOperation(),
        new GetGroupByIdTeamScheduleDayNoteByIdOperation(),
        new GetGroupByIdTeamScheduleDayNoteCountOperation(),
        new ListGroupByIdTeamScheduleDayNotesOperation(),
        new UpdateGroupByIdTeamScheduleDayNoteByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
