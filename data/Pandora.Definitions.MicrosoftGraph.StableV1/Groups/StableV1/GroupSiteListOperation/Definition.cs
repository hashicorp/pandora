// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteListOperation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteListOperation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdListByIdOperationOperation(),
        new DeleteGroupByIdSiteByIdListByIdOperationByIdOperation(),
        new GetGroupByIdSiteByIdListByIdOperationByIdOperation(),
        new GetGroupByIdSiteByIdListByIdOperationCountOperation(),
        new ListGroupByIdSiteByIdListByIdOperationsOperation(),
        new UpdateGroupByIdSiteByIdListByIdOperationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
