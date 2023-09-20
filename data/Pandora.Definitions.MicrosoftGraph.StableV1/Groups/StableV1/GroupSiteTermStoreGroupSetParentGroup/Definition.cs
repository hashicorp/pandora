// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroupSetParentGroup;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSetParentGroup";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdParentGroupOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdParentGroupOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdParentGroupOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdParentGroupOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdParentGroupOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdParentGroupOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
