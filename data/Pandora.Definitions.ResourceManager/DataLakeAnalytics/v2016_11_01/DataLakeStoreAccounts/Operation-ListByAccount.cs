using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.DataLakeStoreAccounts;

internal class ListByAccountOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new AccountId();

    public override Type NestedItemType() => typeof(DataLakeStoreAccountInformationModel);

    public override Type? OptionsObject() => typeof(ListByAccountOperation.ListByAccountOptions);

    public override string? UriSuffix() => "/dataLakeStoreAccounts";

    internal class ListByAccountOptions
    {
        [QueryStringName("$count")]
        [Optional]
        public bool Count { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$orderby")]
        [Optional]
        public string Orderby { get; set; }

        [QueryStringName("$select")]
        [Optional]
        public string Select { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
