using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Recommendations;

internal class ListHistoryForHostingEnvironmentOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new HostingEnvironmentId();

    public override Type NestedItemType() => typeof(RecommendationModel);

    public override Type? OptionsObject() => typeof(ListHistoryForHostingEnvironmentOperation.ListHistoryForHostingEnvironmentOptions);

    public override string? UriSuffix() => "/recommendationHistory";

    internal class ListHistoryForHostingEnvironmentOptions
    {
        [QueryStringName("expiredOnly")]
        [Optional]
        public bool ExpiredOnly { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
