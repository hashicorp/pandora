// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteOnenoteSectionGroupSection;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteOnenoteSectionGroupSection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdCopyToNotebookOperation(),
        new CreateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdCopyToSectionGroupOperation(),
        new CreateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionOperation(),
        new DeleteGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdOperation(),
        new GetGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdOperation(),
        new GetGroupByIdSiteByIdOnenoteSectionGroupByIdSectionCountOperation(),
        new ListGroupByIdSiteByIdOnenoteSectionGroupByIdSectionsOperation(),
        new UpdateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdCopyToNotebookRequestModel),
        typeof(CreateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdCopyToSectionGroupRequestModel)
    };
}
