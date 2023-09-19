// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserChatOperation;

internal class UpdateUserByIdChatByIdOperationByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(TeamsAsyncOperationModel);
    public override ResourceID? ResourceId() => new UserIdChatIdOperationId();
    public override Type? ResponseObject() => typeof(TeamsAsyncOperationModel);
    public override string? UriSuffix() => null;
}
