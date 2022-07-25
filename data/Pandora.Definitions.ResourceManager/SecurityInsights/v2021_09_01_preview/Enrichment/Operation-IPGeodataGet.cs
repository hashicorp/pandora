using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Enrichment;

internal class IPGeodataGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type? ResponseObject() => typeof(EnrichmentIPGeodataModel);

    public override Type? OptionsObject() => typeof(IPGeodataGetOperation.IPGeodataGetOptions);

    public override string? UriSuffix() => "/providers/Microsoft.SecurityInsights/enrichment/ip/geodata";

    internal class IPGeodataGetOptions
    {
        [QueryStringName("ipAddress")]
        public string IPAddress { get; set; }
    }
}
