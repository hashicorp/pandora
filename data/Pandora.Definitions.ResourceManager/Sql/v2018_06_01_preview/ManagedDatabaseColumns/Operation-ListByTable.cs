using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedDatabaseColumns;

internal class ListByTableOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SchemaTableId();

    public override Type NestedItemType() => typeof(DatabaseColumnModel);

    public override Type? OptionsObject() => typeof(ListByTableOperation.ListByTableOptions);

    public override string? UriSuffix() => "/columns";

    internal class ListByTableOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
