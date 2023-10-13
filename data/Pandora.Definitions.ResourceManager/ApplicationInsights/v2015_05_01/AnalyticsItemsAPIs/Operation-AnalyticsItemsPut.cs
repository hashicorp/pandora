using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.AnalyticsItemsAPIs;

internal class AnalyticsItemsPutOperation : Pandora.Definitions.Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ApplicationInsightsComponentAnalyticsItemModel);

    public override ResourceID? ResourceId() => new ProviderComponentId();

    public override Type? ResponseObject() => typeof(ApplicationInsightsComponentAnalyticsItemModel);

    public override Type? OptionsObject() => typeof(AnalyticsItemsPutOperation.AnalyticsItemsPutOptions);

    public override string? UriSuffix() => "/item";

    internal class AnalyticsItemsPutOptions
    {
        [QueryStringName("overrideItem")]
        [Optional]
        public bool OverrideItem { get; set; }
    }
}
