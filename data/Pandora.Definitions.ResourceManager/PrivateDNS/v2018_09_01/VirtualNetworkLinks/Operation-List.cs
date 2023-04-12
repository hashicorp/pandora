using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2018_09_01.VirtualNetworkLinks;

internal class ListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new PrivateDnsZoneId();

    public override Type NestedItemType() => typeof(VirtualNetworkLinkModel);

    public override Type? OptionsObject() => typeof(ListOperation.ListOptions);

    public override string? UriSuffix() => "/virtualNetworkLinks";

    internal class ListOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
