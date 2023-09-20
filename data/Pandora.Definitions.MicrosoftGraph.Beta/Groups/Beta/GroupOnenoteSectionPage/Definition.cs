// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupOnenoteSectionPage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupOnenoteSectionPage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdOnenoteSectionByIdPageByIdCopyToSectionOperation(),
        new CreateGroupByIdOnenoteSectionByIdPageByIdOnenotePatchContentOperation(),
        new CreateGroupByIdOnenoteSectionByIdPageOperation(),
        new DeleteGroupByIdOnenoteSectionByIdPageByIdOperation(),
        new GetGroupByIdOnenoteSectionByIdPageByIdOperation(),
        new GetGroupByIdOnenoteSectionByIdPageCountOperation(),
        new ListGroupByIdOnenoteSectionByIdPagesOperation(),
        new UpdateGroupByIdOnenoteSectionByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdOnenoteSectionByIdPageByIdCopyToSectionRequestModel),
        typeof(CreateGroupByIdOnenoteSectionByIdPageByIdOnenotePatchContentRequestModel)
    };
}
