using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.TrafficFilter;

internal class DetachTrafficFilterUpdateOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new MonitorId();

    public override Type? OptionsObject() => typeof(DetachTrafficFilterUpdateOperation.DetachTrafficFilterUpdateOptions);

    public override string? UriSuffix() => "/detachTrafficFilter";

    internal class DetachTrafficFilterUpdateOptions
    {
        [QueryStringName("rulesetId")]
        [Optional]
        public string RulesetId { get; set; }
    }
}
