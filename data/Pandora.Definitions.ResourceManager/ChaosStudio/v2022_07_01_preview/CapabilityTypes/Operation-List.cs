using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2022_07_01_preview.CapabilityTypes;

internal class ListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new TargetTypeId();

\t\tpublic override Type NestedItemType() => typeof(CapabilityTypeModel);

\t\tpublic override Type? OptionsObject() => typeof(ListOperation.ListOptions);

\t\tpublic override string? UriSuffix() => "/capabilityTypes";

    internal class ListOptions
    {
        [QueryStringName("continuationToken")]
        [Optional]
        public string ContinuationToken { get; set; }
    }
}
