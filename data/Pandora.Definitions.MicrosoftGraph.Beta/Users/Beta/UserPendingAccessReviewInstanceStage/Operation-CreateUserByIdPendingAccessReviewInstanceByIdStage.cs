// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceStage;

internal class CreateUserByIdPendingAccessReviewInstanceByIdStageOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AccessReviewStageModel);
    public override ResourceID? ResourceId() => new UserIdPendingAccessReviewInstanceId();
    public override Type? ResponseObject() => typeof(AccessReviewStageModel);
    public override string? UriSuffix() => "/stages";
}
