using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.PreRules;

internal class ResetCountersOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new PreRuleId();

    public override Type? ResponseObject() => typeof(RuleCounterResetModel);

    public override Type? OptionsObject() => typeof(ResetCountersOperation.ResetCountersOptions);

    public override string? UriSuffix() => "/resetCounters";

    internal class ResetCountersOptions
    {
        [QueryStringName("firewallName")]
        [Optional]
        public string FirewallName { get; set; }
    }
}
