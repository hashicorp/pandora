using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2023_07_01.DeploymentOperations;

internal class ListAtScopeOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ScopedDeploymentId();

    public override Type NestedItemType() => typeof(DeploymentOperationModel);

    public override Type? OptionsObject() => typeof(ListAtScopeOperation.ListAtScopeOptions);

    public override string? UriSuffix() => "/operations";

    internal class ListAtScopeOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
