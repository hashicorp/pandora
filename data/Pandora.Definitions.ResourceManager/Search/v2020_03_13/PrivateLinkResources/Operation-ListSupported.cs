using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_03_13.PrivateLinkResources;

internal class ListSupportedOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new SearchServiceId();

\t\tpublic override Type? ResponseObject() => typeof(PrivateLinkResourcesResultModel);

\t\tpublic override Type? OptionsObject() => typeof(ListSupportedOperation.ListSupportedOptions);

\t\tpublic override string? UriSuffix() => "/privateLinkResources";

    internal class ListSupportedOptions
    {
        [HeaderName("x-ms-client-request-id")]
        [Optional]
        public string XMsClientRequestId { get; set; }
    }
}
