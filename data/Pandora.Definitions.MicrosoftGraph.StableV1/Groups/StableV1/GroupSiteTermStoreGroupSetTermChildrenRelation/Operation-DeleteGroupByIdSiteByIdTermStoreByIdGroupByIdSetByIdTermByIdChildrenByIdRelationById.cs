// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroupSetTermChildrenRelation;

internal class DeleteGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdChildrenByIdRelationByIdOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override ResourceID? ResourceId() => new GroupIdSiteIdTermStoreIdGroupIdSetIdTermIdChildrenIdRelationId();
    public override string? UriSuffix() => null;
}
