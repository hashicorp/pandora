// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionDataLossPreventionPolicy;

internal class CreateUserByIdInformationProtectionDataLossPreventionPolicyEvaluateOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateUserByIdInformationProtectionDataLossPreventionPolicyEvaluateRequestModel);
    public override ResourceID? ResourceId() => new UserId();
    public override Type? ResponseObject() => typeof(DlpEvaluatePoliciesJobResponseModel);
    public override string? UriSuffix() => "/informationProtection/dataLossPreventionPolicies/evaluate";
}
