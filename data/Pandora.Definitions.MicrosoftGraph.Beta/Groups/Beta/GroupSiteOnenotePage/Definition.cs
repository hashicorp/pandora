// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteOnenotePage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteOnenotePage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdOnenotePageByIdCopyToSectionOperation(),
        new CreateGroupByIdSiteByIdOnenotePageByIdOnenotePatchContentOperation(),
        new CreateGroupByIdSiteByIdOnenotePageOperation(),
        new DeleteGroupByIdSiteByIdOnenotePageByIdOperation(),
        new GetGroupByIdSiteByIdOnenotePageByIdOperation(),
        new GetGroupByIdSiteByIdOnenotePageCountOperation(),
        new ListGroupByIdSiteByIdOnenotePagesOperation(),
        new UpdateGroupByIdSiteByIdOnenotePageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdOnenotePageByIdCopyToSectionRequestModel),
        typeof(CreateGroupByIdSiteByIdOnenotePageByIdOnenotePatchContentRequestModel)
    };
}
