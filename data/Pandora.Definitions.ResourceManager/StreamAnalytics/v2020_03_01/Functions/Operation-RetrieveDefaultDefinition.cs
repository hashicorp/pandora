using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.Functions;

internal class RetrieveDefaultDefinitionOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(FunctionRetrieveDefaultDefinitionParametersModel);

\t\tpublic override ResourceID? ResourceId() => new FunctionId();

\t\tpublic override Type? ResponseObject() => typeof(FunctionModel);

\t\tpublic override string? UriSuffix() => "/retrieveDefaultDefinition";


}
