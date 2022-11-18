using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.Enrichment;

internal class DomainWhoisGetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ResourceGroupId();

\t\tpublic override Type? ResponseObject() => typeof(EnrichmentDomainWhoisModel);

\t\tpublic override Type? OptionsObject() => typeof(DomainWhoisGetOperation.DomainWhoisGetOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.SecurityInsights/enrichment/domain/whois";

    internal class DomainWhoisGetOptions
    {
        [QueryStringName("domain")]
        public string Domain { get; set; }
    }
}
