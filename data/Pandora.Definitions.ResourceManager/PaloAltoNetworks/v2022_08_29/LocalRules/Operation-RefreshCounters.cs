using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.LocalRules;

internal class RefreshCountersOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new LocalRuleId();

    public override Type? OptionsObject() => typeof(RefreshCountersOperation.RefreshCountersOptions);

    public override string? UriSuffix() => "/refreshCounters";

    internal class RefreshCountersOptions
    {
        [QueryStringName("firewallName")]
        [Optional]
        public string FirewallName { get; set; }
    }
}
