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

internal class QueriesSearchOperation : Operations.ListOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => typeof(LogAnalyticsQueryPackQuerySearchPropertiesModel);

\t\tpublic override ResourceID? ResourceId() => new QueryPackId();

\t\tpublic override Type NestedItemType() => typeof(LogAnalyticsQueryPackQueryModel);

\t\tpublic override Type? OptionsObject() => typeof(QueriesSearchOperation.QueriesSearchOptions);

\t\tpublic override string? UriSuffix() => "/queries/search";

\t\tpublic override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;

    internal class QueriesSearchOptions
    {
        [QueryStringName("includeBody")]
        [Optional]
        public bool IncludeBody { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
