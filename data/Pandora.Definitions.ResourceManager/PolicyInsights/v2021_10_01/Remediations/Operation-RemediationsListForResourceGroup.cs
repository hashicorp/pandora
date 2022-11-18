using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2021_10_01.Remediations;

internal class RemediationsListForResourceGroupOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ResourceGroupId();

\t\tpublic override Type NestedItemType() => typeof(RemediationModel);

\t\tpublic override Type? OptionsObject() => typeof(RemediationsListForResourceGroupOperation.RemediationsListForResourceGroupOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.PolicyInsights/remediations";

    internal class RemediationsListForResourceGroupOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
