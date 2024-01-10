// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionThreatAssessmentRequestResult;

internal class UpdateUserByIdInformationProtectionThreatAssessmentRequestByIdResultByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ThreatAssessmentResultModel);
    public override ResourceID? ResourceId() => new UserIdInformationProtectionThreatAssessmentRequestIdResultId();
    public override Type? ResponseObject() => typeof(ThreatAssessmentResultModel);
    public override string? UriSuffix() => null;
}
