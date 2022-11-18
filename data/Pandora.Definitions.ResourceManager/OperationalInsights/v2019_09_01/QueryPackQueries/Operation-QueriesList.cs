using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2019_09_01.QueryPackQueries;

internal class QueriesListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new QueryPackId();

\t\tpublic override Type NestedItemType() => typeof(LogAnalyticsQueryPackQueryModel);

\t\tpublic override Type? OptionsObject() => typeof(QueriesListOperation.QueriesListOptions);

\t\tpublic override string? UriSuffix() => "/queries";

    internal class QueriesListOptions
    {
        [QueryStringName("includeBody")]
        [Optional]
        public bool IncludeBody { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
