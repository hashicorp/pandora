// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeOnenoteNotebookSectionGroupSection;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOnenoteNotebookSectionGroupSection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToNotebookOperation(),
        new CreateMeOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToSectionGroupOperation(),
        new CreateMeOnenoteNotebookByIdSectionGroupByIdSectionOperation(),
        new DeleteMeOnenoteNotebookByIdSectionGroupByIdSectionByIdOperation(),
        new GetMeOnenoteNotebookByIdSectionGroupByIdSectionByIdOperation(),
        new GetMeOnenoteNotebookByIdSectionGroupByIdSectionCountOperation(),
        new ListMeOnenoteNotebookByIdSectionGroupByIdSectionsOperation(),
        new UpdateMeOnenoteNotebookByIdSectionGroupByIdSectionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToNotebookRequestModel),
        typeof(CreateMeOnenoteNotebookByIdSectionGroupByIdSectionByIdCopyToSectionGroupRequestModel)
    };
}
