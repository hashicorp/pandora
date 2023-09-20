// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSitePage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSitePage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdPageOperation(),
        new DeleteGroupByIdSiteByIdPageByIdOperation(),
        new GetGroupByIdSiteByIdPageByIdOperation(),
        new GetGroupByIdSiteByIdPageCountOperation(),
        new ListGroupByIdSiteByIdPagesOperation(),
        new UpdateGroupByIdSiteByIdPageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
