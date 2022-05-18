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
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new ContainerAppId();

    public override Type? ResponseObject() => typeof(CustomHostnameAnalysisResultModel);

    public override Type? OptionsObject() => typeof(ListCustomHostNameAnalysisOperation.ListCustomHostNameAnalysisOptions);

    public override string? UriSuffix() => "/listCustomHostNameAnalysis";

    internal class ListCustomHostNameAnalysisOptions
    {
        [QueryStringName("customHostname")]
        [Optional]
        public string CustomHostname { get; set; }
    }
}
