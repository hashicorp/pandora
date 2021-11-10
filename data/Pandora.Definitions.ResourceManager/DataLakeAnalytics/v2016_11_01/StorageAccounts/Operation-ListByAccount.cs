using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.StorageAccounts
{
    internal class ListByAccountOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails() => "nextLink";

        public override ResourceID? ResourceId() => new AccountId();

        public override Type NestedItemType() => typeof(StorageAccountInformationModel);

        public override Type? OptionsObject() => typeof(ListByAccountOperation.ListByAccountOptions);

        public override string? UriSuffix() => "/storageAccounts";

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
}
