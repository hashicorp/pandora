using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.Job;

internal class GetOutputOperation : Operations.GetOperation
{
\t\tpublic override string? ContentType() => "text/plain";

\t\tpublic override ResourceID? ResourceId() => new JobId();

\t\tpublic override Type? ResponseObject() => typeof(string);

\t\tpublic override Type? OptionsObject() => typeof(GetOutputOperation.GetOutputOptions);

\t\tpublic override string? UriSuffix() => "/output";

    internal class GetOutputOptions
    {
        [HeaderName("clientRequestId")]
        [Optional]
        public string ClientRequestId { get; set; }
    }
}
