using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.VCenter;

internal class GetAllVCentersInSiteOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new VMwareSiteId();

    public override Type NestedItemType() => typeof(VCenterModel);

    public override Type? OptionsObject() => typeof(GetAllVCentersInSiteOperation.GetAllVCentersInSiteOptions);

    public override string? UriSuffix() => "/vCenters";

    internal class GetAllVCentersInSiteOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
