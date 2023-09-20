// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationSynchronizationTemplateSchema;

internal class ParseApplicationByIdSynchronizationTemplateByIdSchemaExpressionOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ParseApplicationByIdSynchronizationTemplateByIdSchemaExpressionRequestModel);
    public override ResourceID? ResourceId() => new ApplicationIdSynchronizationTemplateId();
    public override Type? ResponseObject() => typeof(ParseExpressionResponseModel);
    public override string? UriSuffix() => "/schema/parseExpression";
}
