using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.SharedPrivateLinkResources;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(SharedPrivateLinkResourceModel);

\t\tpublic override ResourceID? ResourceId() => new SharedPrivateLinkResourceId();

\t\tpublic override Type? ResponseObject() => typeof(SharedPrivateLinkResourceModel);

\t\tpublic override Type? OptionsObject() => typeof(CreateOrUpdateOperation.CreateOrUpdateOptions);

    internal class CreateOrUpdateOptions
    {
        [HeaderName("x-ms-client-request-id")]
        [Optional]
        public string XMsClientRequestId { get; set; }
    }
}
