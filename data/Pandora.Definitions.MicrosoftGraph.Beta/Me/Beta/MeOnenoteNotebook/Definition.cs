// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnenoteNotebook;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOnenoteNotebook";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOnenoteNotebookByIdCopyNotebookOperation(),
        new CreateMeOnenoteNotebookOperation(),
        new DeleteMeOnenoteNotebookByIdOperation(),
        new GetMeOnenoteNotebookByIdOperation(),
        new GetMeOnenoteNotebookCountOperation(),
        new GetMeOnenoteNotebooksNotebookFromWebUrlOperation(),
        new ListMeOnenoteNotebooksOperation(),
        new UpdateMeOnenoteNotebookByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeOnenoteNotebookByIdCopyNotebookRequestModel),
        typeof(GetMeOnenoteNotebooksNotebookFromWebUrlRequestModel)
    };
}
