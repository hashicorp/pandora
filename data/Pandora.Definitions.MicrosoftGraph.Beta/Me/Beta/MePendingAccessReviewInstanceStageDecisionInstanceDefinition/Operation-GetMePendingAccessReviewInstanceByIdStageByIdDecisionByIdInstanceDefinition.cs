// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceStageDecisionInstanceDefinition;

internal class GetMePendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceDefinitionOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new MePendingAccessReviewInstanceIdStageIdDecisionId();
    public override Type? ResponseObject() => typeof(AccessReviewScheduleDefinitionModel);
    public override string? UriSuffix() => "/instance/definition";
}
