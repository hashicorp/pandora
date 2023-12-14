// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListItemDocumentSetVersion;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteListItemDocumentSetVersion";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdListByIdItemByIdDocumentSetVersionOperation(),
        new DeleteGroupByIdSiteByIdListByIdItemByIdDocumentSetVersionByIdOperation(),
        new GetGroupByIdSiteByIdListByIdItemByIdDocumentSetVersionByIdOperation(),
        new GetGroupByIdSiteByIdListByIdItemByIdDocumentSetVersionCountOperation(),
        new ListGroupByIdSiteByIdListByIdItemByIdDocumentSetVersionsOperation(),
        new RestoreGroupByIdSiteByIdListByIdItemByIdDocumentSetVersionByIdOperation(),
        new UpdateGroupByIdSiteByIdListByIdItemByIdDocumentSetVersionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
