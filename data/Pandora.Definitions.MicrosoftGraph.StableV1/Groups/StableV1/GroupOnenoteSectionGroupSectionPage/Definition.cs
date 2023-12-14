// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupOnenoteSectionGroupSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupOnenoteSectionGroupSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdOnenoteSectionGroupByIdSectionByIdPageByIdCopyToSectionOperation(),
        new CreateGroupByIdOnenoteSectionGroupByIdSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateGroupByIdOnenoteSectionGroupByIdSectionByIdPageOperation(),
        new DeleteGroupByIdOnenoteSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetGroupByIdOnenoteSectionGroupByIdSectionByIdPageByIdOperation(),
        new GetGroupByIdOnenoteSectionGroupByIdSectionByIdPageCountOperation(),
        new ListGroupByIdOnenoteSectionGroupByIdSectionByIdPagesOperation(),
        new UpdateGroupByIdOnenoteSectionGroupByIdSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdOnenoteSectionGroupByIdSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateGroupByIdOnenoteSectionGroupByIdSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
