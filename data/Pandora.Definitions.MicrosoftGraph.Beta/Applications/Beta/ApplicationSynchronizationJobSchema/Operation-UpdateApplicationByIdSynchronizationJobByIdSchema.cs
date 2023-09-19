// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationSynchronizationJobSchema;

internal class UpdateApplicationByIdSynchronizationJobByIdSchemaOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(SynchronizationSchemaModel);
    public override ResourceID? ResourceId() => new ApplicationIdSynchronizationJobId();
    public override Type? ResponseObject() => typeof(SynchronizationSchemaModel);
    public override string? UriSuffix() => "/schema";
}
