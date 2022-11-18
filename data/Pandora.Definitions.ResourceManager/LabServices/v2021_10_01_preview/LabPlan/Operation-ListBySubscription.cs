using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.LabPlan;

internal class ListBySubscriptionOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new SubscriptionId();

\t\tpublic override Type NestedItemType() => typeof(LabPlanModel);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.LabServices/labPlans";


}
