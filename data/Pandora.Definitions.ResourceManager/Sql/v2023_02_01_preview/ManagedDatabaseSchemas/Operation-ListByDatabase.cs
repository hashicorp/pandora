using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedDatabaseSchemas;

internal class ListByDatabaseOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ManagedInstanceDatabaseId();

    public override Type NestedItemType() => typeof(ResourceModel);

    public override Type? OptionsObject() => typeof(ListByDatabaseOperation.ListByDatabaseOptions);

    public override string? UriSuffix() => "/schemas";

    internal class ListByDatabaseOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
