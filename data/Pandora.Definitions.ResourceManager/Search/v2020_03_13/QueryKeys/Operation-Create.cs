using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_03_13.QueryKeys;

internal class CreateOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new CreateQueryKeyId();

\t\tpublic override Type? ResponseObject() => typeof(QueryKeyModel);

\t\tpublic override Type? OptionsObject() => typeof(CreateOperation.CreateOptions);

    internal class CreateOptions
    {
        [HeaderName("x-ms-client-request-id")]
        [Optional]
        public string XMsClientRequestId { get; set; }
    }
}
