// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalSynchronizationJobBulkUpload;

internal class UpdateServicePrincipalByIdSynchronizationJobByIdBulkUploadOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(BulkUploadModel);
    public override ResourceID? ResourceId() => new ServicePrincipalIdSynchronizationJobId();
    public override Type? ResponseObject() => typeof(BulkUploadModel);
    public override string? UriSuffix() => "/bulkUpload";
}
