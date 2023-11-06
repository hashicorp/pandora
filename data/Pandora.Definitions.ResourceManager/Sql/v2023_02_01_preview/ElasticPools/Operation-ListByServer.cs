using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ElasticPools;

internal class ListByServerOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SqlServerId();

    public override Type NestedItemType() => typeof(ElasticPoolModel);

    public override Type? OptionsObject() => typeof(ListByServerOperation.ListByServerOptions);

    public override string? UriSuffix() => "/elasticPools";

    internal class ListByServerOptions
    {
        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }
    }
}
