using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.RecordSets;

internal class ListByDnsZoneOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new DnsZoneId();

\t\tpublic override Type NestedItemType() => typeof(RecordSetModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByDnsZoneOperation.ListByDnsZoneOptions);

\t\tpublic override string? UriSuffix() => "/recordsets";

    internal class ListByDnsZoneOptions
    {
        [QueryStringName("$recordsetnamesuffix")]
        [Optional]
        public string Recordsetnamesuffix { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
