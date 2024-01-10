// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ApplicationTemplates.Beta.ApplicationTemplate;

internal class InstantiateApplicationTemplateByIdOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(InstantiateApplicationTemplateByIdRequestModel);
    public override ResourceID? ResourceId() => new ApplicationTemplateId();
    public override Type? ResponseObject() => typeof(ApplicationServicePrincipalModel);
    public override string? UriSuffix() => "/instantiate";
}
