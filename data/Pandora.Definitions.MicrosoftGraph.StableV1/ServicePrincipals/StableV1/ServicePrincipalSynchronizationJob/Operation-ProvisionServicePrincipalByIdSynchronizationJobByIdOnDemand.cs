// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalSynchronizationJob;

internal class ProvisionServicePrincipalByIdSynchronizationJobByIdOnDemandOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ProvisionServicePrincipalByIdSynchronizationJobByIdOnDemandRequestModel);
    public override ResourceID? ResourceId() => new ServicePrincipalIdSynchronizationJobId();
    public override Type? ResponseObject() => typeof(StringKeyStringValuePairModel);
    public override string? UriSuffix() => "/provisionOnDemand";
}
