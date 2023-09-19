// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteOnenoteNotebookSectionGroupSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteOnenoteNotebookSectionGroupSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdCopyToSectionOperation(),
        new CreateGroupByIdSiteByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateGroupByIdSiteByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageOperation(),
        new DeleteGroupByIdSiteByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetGroupByIdSiteByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetGroupByIdSiteByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageCountOperation(),
        new ListGroupByIdSiteByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPagesOperation(),
        new UpdateGroupByIdSiteByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateGroupByIdSiteByIdOnenoteNotebookByIdSectionGroupByIdSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
