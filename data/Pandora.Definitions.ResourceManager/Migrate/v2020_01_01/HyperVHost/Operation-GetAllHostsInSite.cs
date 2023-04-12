using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.HyperVHost;

internal class GetAllHostsInSiteOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new HyperVSiteId();

    public override Type NestedItemType() => typeof(HyperVHostModel);

    public override Type? OptionsObject() => typeof(GetAllHostsInSiteOperation.GetAllHostsInSiteOptions);

    public override string? UriSuffix() => "/hosts";

    internal class GetAllHostsInSiteOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
