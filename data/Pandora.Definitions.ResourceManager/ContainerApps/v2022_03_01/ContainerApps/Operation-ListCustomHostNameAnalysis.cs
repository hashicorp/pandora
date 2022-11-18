using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerApps;

internal class ListCustomHostNameAnalysisOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new ContainerAppId();

\t\tpublic override Type? ResponseObject() => typeof(CustomHostnameAnalysisResultModel);

\t\tpublic override Type? OptionsObject() => typeof(ListCustomHostNameAnalysisOperation.ListCustomHostNameAnalysisOptions);

\t\tpublic override string? UriSuffix() => "/listCustomHostNameAnalysis";

    internal class ListCustomHostNameAnalysisOptions
    {
        [QueryStringName("customHostname")]
        [Optional]
        public string CustomHostname { get; set; }
    }
}
