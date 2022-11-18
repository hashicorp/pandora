using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DNSResolver.v2022_07_01.OutboundEndpoints;

internal class UpdateOperation : Operations.PatchOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(OutboundEndpointPatchModel);

\t\tpublic override ResourceID? ResourceId() => new OutboundEndpointId();

\t\tpublic override Type? ResponseObject() => typeof(OutboundEndpointModel);

\t\tpublic override Type? OptionsObject() => typeof(UpdateOperation.UpdateOptions);

    internal class UpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
