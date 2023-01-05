using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.Configurations;

internal class ListByServerOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new FlexibleServerId();

    public override Type NestedItemType() => typeof(ConfigurationModel);

    public override Type? OptionsObject() => typeof(ListByServerOperation.ListByServerOptions);

    public override string? UriSuffix() => "/configurations";

    internal class ListByServerOptions
    {
        [QueryStringName("keyword")]
        [Optional]
        public string Keyword { get; set; }

        [QueryStringName("page")]
        [Optional]
        public int Page { get; set; }

        [QueryStringName("pageSize")]
        [Optional]
        public int PageSize { get; set; }

        [QueryStringName("tags")]
        [Optional]
        public string Tags { get; set; }
    }
}
