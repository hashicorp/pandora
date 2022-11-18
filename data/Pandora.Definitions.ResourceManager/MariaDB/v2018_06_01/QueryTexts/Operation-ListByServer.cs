using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.QueryTexts;

internal class ListByServerOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ServerId();

\t\tpublic override Type NestedItemType() => typeof(QueryTextModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByServerOperation.ListByServerOptions);

\t\tpublic override string? UriSuffix() => "/queryTexts";

    internal class ListByServerOptions
    {
        [QueryStringName("queryIds")]
        public List<string> QueryIds { get; set; }
    }
}
