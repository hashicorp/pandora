using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_03_15.CosmosDB;

internal class CollectionPartitionListUsagesOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new CollectionId();

    public override Type? ResponseObject() => typeof(PartitionUsagesResultModel);

    public override Type? OptionsObject() => typeof(CollectionPartitionListUsagesOperation.CollectionPartitionListUsagesOptions);

    public override string? UriSuffix() => "/partitions/usages";

    internal class CollectionPartitionListUsagesOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
