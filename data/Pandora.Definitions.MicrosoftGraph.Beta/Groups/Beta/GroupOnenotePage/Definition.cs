// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupOnenotePage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupOnenotePage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdOnenotePageByIdCopyToSectionOperation(),
        new CreateGroupByIdOnenotePageByIdOnenotePatchContentOperation(),
        new CreateGroupByIdOnenotePageOperation(),
        new DeleteGroupByIdOnenotePageByIdOperation(),
        new GetGroupByIdOnenotePageByIdOperation(),
        new GetGroupByIdOnenotePageCountOperation(),
        new ListGroupByIdOnenotePagesOperation(),
        new UpdateGroupByIdOnenotePageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdOnenotePageByIdCopyToSectionRequestModel),
        typeof(CreateGroupByIdOnenotePageByIdOnenotePatchContentRequestModel)
    };
}
