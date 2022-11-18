using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.Services;

internal class UpdateOperation : Operations.PatchOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(SearchServiceUpdateModel);

\t\tpublic override ResourceID? ResourceId() => new SearchServiceId();

\t\tpublic override Type? ResponseObject() => typeof(SearchServiceModel);

\t\tpublic override Type? OptionsObject() => typeof(UpdateOperation.UpdateOptions);

    internal class UpdateOptions
    {
        [HeaderName("x-ms-client-request-id")]
        [Optional]
        public string XMsClientRequestId { get; set; }
    }
}
