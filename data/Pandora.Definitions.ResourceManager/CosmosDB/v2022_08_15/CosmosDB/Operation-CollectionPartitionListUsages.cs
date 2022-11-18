using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.CosmosDB;

internal class CollectionPartitionListUsagesOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new CollectionId();

\t\tpublic override Type? ResponseObject() => typeof(PartitionUsagesResultModel);

\t\tpublic override Type? OptionsObject() => typeof(CollectionPartitionListUsagesOperation.CollectionPartitionListUsagesOptions);

\t\tpublic override string? UriSuffix() => "/partitions/usages";

    internal class CollectionPartitionListUsagesOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
