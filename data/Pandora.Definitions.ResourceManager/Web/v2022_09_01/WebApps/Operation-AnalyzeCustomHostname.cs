using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

internal class AnalyzeCustomHostnameOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new AppServiceId();

    public override Type? ResponseObject() => typeof(CustomHostnameAnalysisResultModel);

    public override Type? OptionsObject() => typeof(AnalyzeCustomHostnameOperation.AnalyzeCustomHostnameOptions);

    public override string? UriSuffix() => "/analyzeCustomHostname";

    internal class AnalyzeCustomHostnameOptions
    {
        [QueryStringName("hostName")]
        [Optional]
        public string HostName { get; set; }
    }
}
