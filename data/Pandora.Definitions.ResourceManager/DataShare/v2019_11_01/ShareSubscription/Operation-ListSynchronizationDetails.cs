using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.ShareSubscription;

internal class ListSynchronizationDetailsOperation : Pandora.Definitions.Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => typeof(ShareSubscriptionSynchronizationModel);

    public override ResourceID? ResourceId() => new ShareSubscriptionId();

    public override Type NestedItemType() => typeof(SynchronizationDetailsModel);

    public override Type? OptionsObject() => typeof(ListSynchronizationDetailsOperation.ListSynchronizationDetailsOptions);

    public override string? UriSuffix() => "/listSynchronizationDetails";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;

    internal class ListSynchronizationDetailsOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$orderby")]
        [Optional]
        public string Orderby { get; set; }
    }
}
