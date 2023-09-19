// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPermissionGrant;

internal class GetUserByIdPermissionGrantByIdMemberObjectOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(GetUserByIdPermissionGrantByIdMemberObjectRequestModel);
    public override ResourceID? ResourceId() => new UserIdPermissionGrantId();
    public override Type? ResponseObject() => typeof(BaseCollectionPaginationCountResponseModel);
    public override string? UriSuffix() => "/getMemberObjects";
}
