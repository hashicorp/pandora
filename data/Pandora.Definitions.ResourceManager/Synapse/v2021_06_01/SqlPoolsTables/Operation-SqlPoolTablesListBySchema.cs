using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsTables;

internal class SqlPoolTablesListBySchemaOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SchemaId();

    public override Type NestedItemType() => typeof(ResourceModel);

    public override Type? OptionsObject() => typeof(SqlPoolTablesListBySchemaOperation.SqlPoolTablesListBySchemaOptions);

    public override string? UriSuffix() => "/tables";

    internal class SqlPoolTablesListBySchemaOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
