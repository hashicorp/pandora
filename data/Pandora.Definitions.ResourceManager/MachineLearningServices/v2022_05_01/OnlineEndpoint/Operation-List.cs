using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OnlineEndpoint;

internal class ListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new WorkspaceId();

    public override Type NestedItemType() => typeof(OnlineEndpointTrackedResourceModel);

    public override Type? OptionsObject() => typeof(ListOperation.ListOptions);

    public override string? UriSuffix() => "/onlineEndpoints";

    internal class ListOptions
    {
        [QueryStringName("computeType")]
        [Optional]
        public EndpointComputeTypeConstant ComputeType { get; set; }

        [QueryStringName("count")]
        [Optional]
        public int Count { get; set; }

        [QueryStringName("name")]
        [Optional]
        public string Name { get; set; }

        [QueryStringName("orderBy")]
        [Optional]
        public OrderStringConstant OrderBy { get; set; }

        [QueryStringName("properties")]
        [Optional]
        public string Properties { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }

        [QueryStringName("tags")]
        [Optional]
        public string Tags { get; set; }
    }
}
