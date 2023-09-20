// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserVirtualEvent;

internal class UpdateUserByIdVirtualEventOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UserVirtualEventsRootModel);
    public override ResourceID? ResourceId() => new UserId();
    public override Type? ResponseObject() => typeof(UserVirtualEventsRootModel);
    public override string? UriSuffix() => "/virtualEvents";
}
