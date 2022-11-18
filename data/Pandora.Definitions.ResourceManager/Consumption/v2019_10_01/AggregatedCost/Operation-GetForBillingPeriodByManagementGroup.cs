using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.AggregatedCost;

internal class GetForBillingPeriodByManagementGroupOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new Providers2BillingPeriodId();

\t\tpublic override Type? ResponseObject() => typeof(ManagementGroupAggregatedCostResultModel);

\t\tpublic override string? UriSuffix() => "/Microsoft.Consumption/aggregatedCost";


}
