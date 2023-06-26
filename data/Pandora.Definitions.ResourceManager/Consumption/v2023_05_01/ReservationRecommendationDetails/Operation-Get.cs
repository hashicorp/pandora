using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.ReservationRecommendationDetails;

internal class GetOperation : Pandora.Definitions.Operations.GetOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new ScopeId();

    public override Type? ResponseObject() => typeof(ReservationRecommendationDetailsModelModel);

    public override Type? OptionsObject() => typeof(GetOperation.GetOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Consumption/reservationRecommendationDetails";

    internal class GetOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("lookBackPeriod")]
        public LookBackPeriodConstant LookBackPeriod { get; set; }

        [QueryStringName("product")]
        public string Product { get; set; }

        [QueryStringName("region")]
        public string Region { get; set; }

        [QueryStringName("scope")]
        public ScopeConstant Scope { get; set; }

        [QueryStringName("term")]
        public TermConstant Term { get; set; }
    }
}
