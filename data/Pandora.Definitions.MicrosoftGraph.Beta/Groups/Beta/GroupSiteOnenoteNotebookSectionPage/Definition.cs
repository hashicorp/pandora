// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteOnenoteNotebookSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteOnenoteNotebookSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdOnenoteNotebookByIdSectionByIdPageByIdCopyToSectionOperation(),
        new CreateGroupByIdSiteByIdOnenoteNotebookByIdSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateGroupByIdSiteByIdOnenoteNotebookByIdSectionByIdPageOperation(),
        new DeleteGroupByIdSiteByIdOnenoteNotebookByIdSectionByIdPageByIdOperation(),
        new GetGroupByIdSiteByIdOnenoteNotebookByIdSectionByIdPageByIdOperation(),
        new GetGroupByIdSiteByIdOnenoteNotebookByIdSectionByIdPageCountOperation(),
        new ListGroupByIdSiteByIdOnenoteNotebookByIdSectionByIdPagesOperation(),
        new UpdateGroupByIdSiteByIdOnenoteNotebookByIdSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdOnenoteNotebookByIdSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateGroupByIdSiteByIdOnenoteNotebookByIdSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
