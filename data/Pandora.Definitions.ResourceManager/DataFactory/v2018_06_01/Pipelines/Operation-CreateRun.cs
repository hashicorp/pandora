using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Pipelines;

internal class CreateRunOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(Dictionary<string, object>);

    public override ResourceID? ResourceId() => new PipelineId();

    public override Type? ResponseObject() => typeof(CreateRunResponseModel);

    public override Type? OptionsObject() => typeof(CreateRunOperation.CreateRunOptions);

    public override string? UriSuffix() => "/createRun";

    internal class CreateRunOptions
    {
        [QueryStringName("isRecovery")]
        [Optional]
        public bool IsRecovery { get; set; }

        [QueryStringName("referencePipelineRunId")]
        [Optional]
        public string ReferencePipelineRunId { get; set; }

        [QueryStringName("startActivityName")]
        [Optional]
        public string StartActivityName { get; set; }

        [QueryStringName("startFromFailure")]
        [Optional]
        public bool StartFromFailure { get; set; }
    }
}
