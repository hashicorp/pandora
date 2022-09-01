using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDB;

internal class CollectionListUsagesOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new CollectionId();

    public override Type? ResponseObject() => typeof(UsagesResultModel);

    public override Type? OptionsObject() => typeof(CollectionListUsagesOperation.CollectionListUsagesOptions);

    public override string? UriSuffix() => "/usages";

    internal class CollectionListUsagesOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
