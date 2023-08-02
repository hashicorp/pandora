using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;

internal class ListWebAppsOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new HostingEnvironmentId();

    public override Type NestedItemType() => typeof(SiteModel);

    public override Type? OptionsObject() => typeof(ListWebAppsOperation.ListWebAppsOptions);

    public override string? UriSuffix() => "/sites";

    internal class ListWebAppsOptions
    {
        [QueryStringName("propertiesToInclude")]
        [Optional]
        public string PropertiesToInclude { get; set; }
    }
}
