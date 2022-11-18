using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Reports;

internal class ListByTimeOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ServiceId();

\t\tpublic override Type NestedItemType() => typeof(ReportRecordContractModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByTimeOperation.ListByTimeOptions);

\t\tpublic override string? UriSuffix() => "/reports/byTime";

    internal class ListByTimeOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }

        [QueryStringName("interval")]
        public string Interval { get; set; }

        [QueryStringName("$orderby")]
        [Optional]
        public string Orderby { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
