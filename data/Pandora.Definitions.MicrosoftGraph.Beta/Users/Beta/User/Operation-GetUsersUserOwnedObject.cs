// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.User;

internal class GetUsersUserOwnedObjectOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(GetUsersUserOwnedObjectRequestModel);
    public override ResourceID? ResourceId() => null;
    public override Type? ResponseObject() => typeof(DirectoryObjectModel);
    public override string? UriSuffix() => "/users/getUserOwnedObjects";
}
