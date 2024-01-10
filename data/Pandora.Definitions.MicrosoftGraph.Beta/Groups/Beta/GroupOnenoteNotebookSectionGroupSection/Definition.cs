// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupOnenoteNotebookSectionGroupSection;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupOnenoteNotebookSectionGroupSection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToNotebookOperation(),
        new CreateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToSectionGroupOperation(),
        new CreateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionOperation(),
        new DeleteGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdOperation(),
        new GetGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdOperation(),
        new GetGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionCountOperation(),
        new ListGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionsOperation(),
        new UpdateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToNotebookRequestModel),
        typeof(CreateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToSectionGroupRequestModel)
    };
}
