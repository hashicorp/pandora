using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.CheckDnsAvailabilities;

internal class CheckDnsNameAvailabilityOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new LocationId();

    public override Type? ResponseObject() => typeof(DnsNameAvailabilityResultModel);

    public override Type? OptionsObject() => typeof(CheckDnsNameAvailabilityOperation.CheckDnsNameAvailabilityOptions);

    public override string? UriSuffix() => "/checkDnsNameAvailability";

    internal class CheckDnsNameAvailabilityOptions
    {
        [QueryStringName("domainNameLabel")]
        public string DomainNameLabel { get; set; }
    }
}
