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

internal class ExtendSoftwareAssuranceBenefitOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(SoftwareAssuranceChangeRequestModel);

\t\tpublic override ResourceID? ResourceId() => new ClusterId();

\t\tpublic override Type? ResponseObject() => typeof(ClusterModel);

\t\tpublic override string? UriSuffix() => "/extendSoftwareAssuranceBenefit";


}
