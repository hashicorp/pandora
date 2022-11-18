using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.AggregatedCost;

internal class GetByManagementGroupOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ManagementGroupId();

\t\tpublic override Type? ResponseObject() => typeof(ManagementGroupAggregatedCostResultModel);

\t\tpublic override Type? OptionsObject() => typeof(GetByManagementGroupOperation.GetByManagementGroupOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Consumption/aggregatedcost";

    internal class GetByManagementGroupOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
