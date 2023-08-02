using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalSynchronizationTemplateSchema;

internal class ParseSchemaExpressionOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ParseSchemaExpressionRequestModel);
    public override ResourceID? ResourceId() => new SynchronizationTemplateId();
    public override Type? ResponseObject() => typeof(ParseExpressionResponseModel);
    public override string? UriSuffix() => "/schema/parseExpression";
}
