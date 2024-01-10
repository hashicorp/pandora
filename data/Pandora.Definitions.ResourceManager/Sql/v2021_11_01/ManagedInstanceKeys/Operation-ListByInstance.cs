using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedInstanceKeys;

internal class ListByInstanceOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SqlManagedInstanceId();

    public override Type NestedItemType() => typeof(ManagedInstanceKeyModel);

    public override Type? OptionsObject() => typeof(ListByInstanceOperation.ListByInstanceOptions);

    public override string? UriSuffix() => "/keys";

    internal class ListByInstanceOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
