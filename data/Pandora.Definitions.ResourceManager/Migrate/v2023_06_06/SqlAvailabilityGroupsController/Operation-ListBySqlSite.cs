using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlAvailabilityGroupsController;

internal class ListBySqlSiteOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SqlSiteId();

    public override Type NestedItemType() => typeof(SqlAvailabilityGroupModel);

    public override Type? OptionsObject() => typeof(ListBySqlSiteOperation.ListBySqlSiteOptions);

    public override string? UriSuffix() => "/sqlAvailabilityGroups";

    internal class ListBySqlSiteOptions
    {
        [QueryStringName("continuationToken")]
        [Optional]
        public string ContinuationToken { get; set; }

        [QueryStringName("filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("top")]
        [Optional]
        public string Top { get; set; }

        [QueryStringName("totalRecordCount")]
        [Optional]
        public int TotalRecordCount { get; set; }
    }
}
