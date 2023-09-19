// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalSynchronizationJobBulkUpload;

internal class CreateUpdateServicePrincipalByIdSynchronizationJobByIdBulkUploadValueOperation : Operations.PutOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(RawFile);
    public override ResourceID? ResourceId() => new ServicePrincipalIdSynchronizationJobId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/bulkUpload/$value";
}
