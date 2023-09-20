// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.ApplicationSynchronizationTemplateSchema;

internal class UpdateApplicationByIdSynchronizationTemplateByIdSchemaOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(SynchronizationSchemaModel);
    public override ResourceID? ResourceId() => new ApplicationIdSynchronizationTemplateId();
    public override Type? ResponseObject() => typeof(SynchronizationSchemaModel);
    public override string? UriSuffix() => "/schema";
}
