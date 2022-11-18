using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsRevisions;

internal class ListRevisionsOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ContainerAppId();

\t\tpublic override Type NestedItemType() => typeof(RevisionModel);

\t\tpublic override Type? OptionsObject() => typeof(ListRevisionsOperation.ListRevisionsOptions);

\t\tpublic override string? UriSuffix() => "/revisions";

    internal class ListRevisionsOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
