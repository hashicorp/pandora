using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Query;

internal class UsageByExternalCloudProviderTypeOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(QueryDefinitionModel);

\t\tpublic override ResourceID? ResourceId() => new ExternalCloudProviderTypeId();

\t\tpublic override Type? ResponseObject() => typeof(QueryResultModel);

\t\tpublic override string? UriSuffix() => "/query";


}
