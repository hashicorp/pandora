using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.OperationalizationClusters;

internal class ComputeListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type NestedItemType() => typeof(ComputeResourceModel);

\t\tpublic override Type? OptionsObject() => typeof(ComputeListOperation.ComputeListOptions);

\t\tpublic override string? UriSuffix() => "/computes";

    internal class ComputeListOptions
    {
        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }
    }
}
