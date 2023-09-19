// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteColumn;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteColumn";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdColumnOperation(),
        new DeleteGroupByIdSiteByIdColumnByIdOperation(),
        new GetGroupByIdSiteByIdColumnByIdOperation(),
        new GetGroupByIdSiteByIdColumnCountOperation(),
        new ListGroupByIdSiteByIdColumnsOperation(),
        new UpdateGroupByIdSiteByIdColumnByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
