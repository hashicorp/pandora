using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Functions;

internal class RetrieveDefaultDefinitionOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(FunctionRetrieveDefaultDefinitionParametersModel);

    public override ResourceID? ResourceId() => new FunctionId();

    public override Type? ResponseObject() => typeof(FunctionModel);

    public override string? UriSuffix() => "/retrieveDefaultDefinition";


}
