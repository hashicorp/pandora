using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DatabaseColumns;

internal class ListByDatabaseOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new DatabaseId();

    public override Type NestedItemType() => typeof(DatabaseColumnModel);

    public override Type? OptionsObject() => typeof(ListByDatabaseOperation.ListByDatabaseOptions);

    public override string? UriSuffix() => "/columns";

    internal class ListByDatabaseOptions
    {
        [QueryStringName("column")]
        [Optional]
        public List<string> Column { get; set; }

        [QueryStringName("orderBy")]
        [Optional]
        public List<string> OrderBy { get; set; }

        [QueryStringName("schema")]
        [Optional]
        public List<string> Schema { get; set; }

        [QueryStringName("table")]
        [Optional]
        public List<string> Table { get; set; }
    }
}
