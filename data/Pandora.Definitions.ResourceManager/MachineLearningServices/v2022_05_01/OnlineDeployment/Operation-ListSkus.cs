using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OnlineDeployment;

internal class ListSkusOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new OnlineEndpointDeploymentId();

\t\tpublic override Type NestedItemType() => typeof(SkuResourceModel);

\t\tpublic override Type? OptionsObject() => typeof(ListSkusOperation.ListSkusOptions);

\t\tpublic override string? UriSuffix() => "/skus";

    internal class ListSkusOptions
    {
        [QueryStringName("count")]
        [Optional]
        public int Count { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }
    }
}
