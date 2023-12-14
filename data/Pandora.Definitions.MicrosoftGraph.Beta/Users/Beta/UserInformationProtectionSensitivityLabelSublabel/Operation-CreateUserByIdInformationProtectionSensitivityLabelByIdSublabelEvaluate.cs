// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionSensitivityLabelSublabel;

internal class CreateUserByIdInformationProtectionSensitivityLabelByIdSublabelEvaluateOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateUserByIdInformationProtectionSensitivityLabelByIdSublabelEvaluateRequestModel);
    public override ResourceID? ResourceId() => new UserIdInformationProtectionSensitivityLabelId();
    public override Type? ResponseObject() => typeof(EvaluateLabelJobResponseModel);
    public override string? UriSuffix() => "/sublabels/evaluate";
}
