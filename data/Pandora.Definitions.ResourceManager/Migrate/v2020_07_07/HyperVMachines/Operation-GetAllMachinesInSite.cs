using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.HyperVMachines;

internal class GetAllMachinesInSiteOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new HyperVSiteId();

    public override Type NestedItemType() => typeof(HyperVMachineModel);

    public override Type? OptionsObject() => typeof(GetAllMachinesInSiteOperation.GetAllMachinesInSiteOptions);

    public override string? UriSuffix() => "/machines";

    internal class GetAllMachinesInSiteOptions
    {
        [QueryStringName("continuationToken")]
        [Optional]
        public string ContinuationToken { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }

        [QueryStringName("totalRecordCount")]
        [Optional]
        public int TotalRecordCount { get; set; }
    }
}
