using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedInstances;

internal class ListByInstancePoolOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new InstancePoolId();

    public override Type NestedItemType() => typeof(ManagedInstanceModel);

    public override Type? OptionsObject() => typeof(ListByInstancePoolOperation.ListByInstancePoolOptions);

    public override string? UriSuffix() => "/managedInstances";

    internal class ListByInstancePoolOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
