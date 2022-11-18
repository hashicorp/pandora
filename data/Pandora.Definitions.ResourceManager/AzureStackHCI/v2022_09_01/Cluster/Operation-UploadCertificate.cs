using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_09_01.Cluster;

internal class UploadCertificateOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
        };

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(UploadCertificateRequestModel);

\t\tpublic override ResourceID? ResourceId() => new ClusterId();

\t\tpublic override string? UriSuffix() => "/uploadCertificate";


}
