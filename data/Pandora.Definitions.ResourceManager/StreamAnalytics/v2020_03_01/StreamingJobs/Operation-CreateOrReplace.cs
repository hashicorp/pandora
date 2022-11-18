using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.StreamingJobs;

internal class CreateOrReplaceOperation : Operations.PutOperation
{
\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(StreamingJobModel);

\t\tpublic override ResourceID? ResourceId() => new StreamingJobId();

\t\tpublic override Type? ResponseObject() => typeof(StreamingJobModel);

\t\tpublic override Type? OptionsObject() => typeof(CreateOrReplaceOperation.CreateOrReplaceOptions);

    internal class CreateOrReplaceOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }

        [HeaderName("If-None-Match")]
        [Optional]
        public string IfNoneMatch { get; set; }
    }
}
