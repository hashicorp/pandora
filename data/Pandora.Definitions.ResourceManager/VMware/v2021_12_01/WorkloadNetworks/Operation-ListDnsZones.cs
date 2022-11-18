using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.WorkloadNetworks;

internal class ListDnsZonesOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new PrivateCloudId();

\t\tpublic override Type NestedItemType() => typeof(WorkloadNetworkDnsZoneModel);

\t\tpublic override string? UriSuffix() => "/workloadNetworks/default/dnsZones";


}
