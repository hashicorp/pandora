using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Diagnostics;

internal class ExecuteSiteAnalysisSlotOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new DiagnosticAnalysisId();

    public override Type? ResponseObject() => typeof(DiagnosticAnalysisModel);

    public override Type? OptionsObject() => typeof(ExecuteSiteAnalysisSlotOperation.ExecuteSiteAnalysisSlotOptions);

    public override string? UriSuffix() => "/execute";

    internal class ExecuteSiteAnalysisSlotOptions
    {
        [QueryStringName("endTime")]
        [Optional]
        public string EndTime { get; set; }

        [QueryStringName("startTime")]
        [Optional]
        public string StartTime { get; set; }

        [QueryStringName("timeGrain")]
        [Optional]
        public string TimeGrain { get; set; }
    }
}
