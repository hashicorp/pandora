// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupOnenoteNotebook;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupOnenoteNotebook";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdOnenoteNotebookByIdCopyNotebookOperation(),
        new CreateGroupByIdOnenoteNotebookOperation(),
        new DeleteGroupByIdOnenoteNotebookByIdOperation(),
        new GetGroupByIdOnenoteNotebookByIdOperation(),
        new GetGroupByIdOnenoteNotebookCountOperation(),
        new GetGroupByIdOnenoteNotebooksNotebookFromWebUrlOperation(),
        new ListGroupByIdOnenoteNotebooksOperation(),
        new UpdateGroupByIdOnenoteNotebookByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdOnenoteNotebookByIdCopyNotebookRequestModel),
        typeof(GetGroupByIdOnenoteNotebooksNotebookFromWebUrlRequestModel)
    };
}
