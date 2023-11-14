using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ResourceProviders;

internal class ListGeoRegionsOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(GeoRegionModel);

    public override Type? OptionsObject() => typeof(ListGeoRegionsOperation.ListGeoRegionsOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Web/geoRegions";

    internal class ListGeoRegionsOptions
    {
        [QueryStringName("linuxDynamicWorkersEnabled")]
        [Optional]
        public bool LinuxDynamicWorkersEnabled { get; set; }

        [QueryStringName("linuxWorkersEnabled")]
        [Optional]
        public bool LinuxWorkersEnabled { get; set; }

        [QueryStringName("sku")]
        [Optional]
        public SkuNameConstant Sku { get; set; }

        [QueryStringName("xenonWorkersEnabled")]
        [Optional]
        public bool XenonWorkersEnabled { get; set; }
    }
}
