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

internal class CreateOperation : Operations.PutOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Created,
        };

    public override Type? RequestObject() => typeof(JobCreateParametersModel);

\t\tpublic override ResourceID? ResourceId() => new JobId();

\t\tpublic override Type? ResponseObject() => typeof(JobModel);

\t\tpublic override Type? OptionsObject() => typeof(CreateOperation.CreateOptions);

    internal class CreateOptions
    {
        [HeaderName("clientRequestId")]
        [Optional]
        public string ClientRequestId { get; set; }
    }
}
