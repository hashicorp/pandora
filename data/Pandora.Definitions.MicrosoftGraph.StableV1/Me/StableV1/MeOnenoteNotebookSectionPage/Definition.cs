// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeOnenoteNotebookSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOnenoteNotebookSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOnenoteNotebookByIdSectionByIdPageByIdCopyToSectionOperation(),
        new CreateMeOnenoteNotebookByIdSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateMeOnenoteNotebookByIdSectionByIdPageOperation(),
        new DeleteMeOnenoteNotebookByIdSectionByIdPageByIdOperation(),
        new GetMeOnenoteNotebookByIdSectionByIdPageByIdOperation(),
        new GetMeOnenoteNotebookByIdSectionByIdPageCountOperation(),
        new ListMeOnenoteNotebookByIdSectionByIdPagesOperation(),
        new UpdateMeOnenoteNotebookByIdSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeOnenoteNotebookByIdSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateMeOnenoteNotebookByIdSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
