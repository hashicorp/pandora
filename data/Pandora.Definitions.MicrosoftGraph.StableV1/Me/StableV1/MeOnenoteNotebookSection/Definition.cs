// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeOnenoteNotebookSection;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOnenoteNotebookSection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOnenoteNotebookByIdSectionByIdCopyToNotebookOperation(),
        new CreateMeOnenoteNotebookByIdSectionByIdCopyToSectionGroupOperation(),
        new CreateMeOnenoteNotebookByIdSectionOperation(),
        new DeleteMeOnenoteNotebookByIdSectionByIdOperation(),
        new GetMeOnenoteNotebookByIdSectionByIdOperation(),
        new GetMeOnenoteNotebookByIdSectionCountOperation(),
        new ListMeOnenoteNotebookByIdSectionsOperation(),
        new UpdateMeOnenoteNotebookByIdSectionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeOnenoteNotebookByIdSectionByIdCopyToNotebookRequestModel),
        typeof(CreateMeOnenoteNotebookByIdSectionByIdCopyToSectionGroupRequestModel)
    };
}
