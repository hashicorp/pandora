using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.FileShares;

internal class LeaseOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(LeaseShareRequestModel);

\t\tpublic override ResourceID? ResourceId() => new ShareId();

\t\tpublic override Type? ResponseObject() => typeof(LeaseShareResponseModel);

\t\tpublic override Type? OptionsObject() => typeof(LeaseOperation.LeaseOptions);

\t\tpublic override string? UriSuffix() => "/lease";

    internal class LeaseOptions
    {
        [HeaderName("x-ms-snapshot")]
        [Optional]
        public string XMsSnapshot { get; set; }
    }
}
