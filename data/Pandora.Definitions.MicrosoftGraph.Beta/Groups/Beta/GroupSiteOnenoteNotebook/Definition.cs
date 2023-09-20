// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteOnenoteNotebook;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteOnenoteNotebook";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdOnenoteNotebookByIdCopyNotebookOperation(),
        new CreateGroupByIdSiteByIdOnenoteNotebookOperation(),
        new DeleteGroupByIdSiteByIdOnenoteNotebookByIdOperation(),
        new GetGroupByIdSiteByIdOnenoteNotebookByIdOperation(),
        new GetGroupByIdSiteByIdOnenoteNotebookCountOperation(),
        new GetGroupByIdSiteByIdOnenoteNotebooksNotebookFromWebUrlOperation(),
        new ListGroupByIdSiteByIdOnenoteNotebooksOperation(),
        new UpdateGroupByIdSiteByIdOnenoteNotebookByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdOnenoteNotebookByIdCopyNotebookRequestModel),
        typeof(GetGroupByIdSiteByIdOnenoteNotebooksNotebookFromWebUrlRequestModel)
    };
}
