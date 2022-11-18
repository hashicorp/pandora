using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.Location;

internal class ListSupportedVirtualMachineSkusOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new LocationId();

\t\tpublic override Type NestedItemType() => typeof(SupportedSkuModel);

\t\tpublic override Type? OptionsObject() => typeof(ListSupportedVirtualMachineSkusOperation.ListSupportedVirtualMachineSkusOptions);

\t\tpublic override string? UriSuffix() => "/virtualMachineSkus";

    internal class ListSupportedVirtualMachineSkusOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("maxresults")]
        [Optional]
        public int Maxresults { get; set; }
    }
}
