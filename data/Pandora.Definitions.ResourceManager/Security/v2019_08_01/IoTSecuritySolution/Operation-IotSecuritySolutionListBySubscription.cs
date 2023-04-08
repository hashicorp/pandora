using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecuritySolution;

internal class IotSecuritySolutionListBySubscriptionOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(IoTSecuritySolutionModelModel);

    public override Type? OptionsObject() => typeof(IotSecuritySolutionListBySubscriptionOperation.IotSecuritySolutionListBySubscriptionOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Security/iotSecuritySolutions";

    internal class IotSecuritySolutionListBySubscriptionOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
