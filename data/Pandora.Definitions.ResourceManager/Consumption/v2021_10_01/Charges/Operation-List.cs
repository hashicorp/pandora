using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Charges;

internal class ListOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ScopeId();

\t\tpublic override Type? ResponseObject() => typeof(ChargesListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(ListOperation.ListOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Consumption/charges";

    internal class ListOptions
    {
        [QueryStringName("$apply")]
        [Optional]
        public string Apply { get; set; }

        [QueryStringName("endDate")]
        [Optional]
        public string EndDate { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("startDate")]
        [Optional]
        public string StartDate { get; set; }
    }
}
