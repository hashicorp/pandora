using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HardwareSecurityModules.v2021_11_30.DedicatedHsms;

internal class DedicatedHsmListBySubscriptionOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new SubscriptionId();

\t\tpublic override Type NestedItemType() => typeof(DedicatedHsmModel);

\t\tpublic override Type? OptionsObject() => typeof(DedicatedHsmListBySubscriptionOperation.DedicatedHsmListBySubscriptionOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.HardwareSecurityModules/dedicatedHSMs";

    internal class DedicatedHsmListBySubscriptionOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
