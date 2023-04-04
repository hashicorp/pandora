using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Enrichment;

internal class Definition : ResourceDefinition
{
    public string Name => "Enrichment";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DomainWhoisGetOperation(),
        new IPGeodataGetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EnrichmentDomainWhoisModel),
        typeof(EnrichmentDomainWhoisContactModel),
        typeof(EnrichmentDomainWhoisContactsModel),
        typeof(EnrichmentDomainWhoisDetailsModel),
        typeof(EnrichmentDomainWhoisRegistrarDetailsModel),
        typeof(EnrichmentIPGeodataModel),
    };
}
