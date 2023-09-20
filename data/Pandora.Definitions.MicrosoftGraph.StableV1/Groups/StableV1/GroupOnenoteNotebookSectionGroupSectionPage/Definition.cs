// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupOnenoteNotebookSectionGroupSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupOnenoteNotebookSectionGroupSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdCopyToSectionOperation(),
        new CreateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageOperation(),
        new DeleteGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageCountOperation(),
        new ListGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPagesOperation(),
        new UpdateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateGroupByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
