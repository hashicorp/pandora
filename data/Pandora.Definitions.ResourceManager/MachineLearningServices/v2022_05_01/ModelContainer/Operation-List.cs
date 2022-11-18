using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.ModelContainer;

internal class ListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type NestedItemType() => typeof(ModelContainerResourceModel);

\t\tpublic override Type? OptionsObject() => typeof(ListOperation.ListOptions);

\t\tpublic override string? UriSuffix() => "/models";

    internal class ListOptions
    {
        [QueryStringName("count")]
        [Optional]
        public int Count { get; set; }

        [QueryStringName("listViewType")]
        [Optional]
        public ListViewTypeConstant ListViewType { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }
    }
}
