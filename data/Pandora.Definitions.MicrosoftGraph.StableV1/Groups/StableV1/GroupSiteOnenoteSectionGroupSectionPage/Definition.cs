// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteOnenoteSectionGroupSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteOnenoteSectionGroupSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdPageByIdCopyToSectionOperation(),
        new CreateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdPageOperation(),
        new DeleteGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdPageCountOperation(),
        new ListGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdPagesOperation(),
        new UpdateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateGroupByIdSiteByIdOnenoteSectionGroupByIdSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
