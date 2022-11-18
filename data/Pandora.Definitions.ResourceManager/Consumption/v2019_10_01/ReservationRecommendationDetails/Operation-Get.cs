using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.ReservationRecommendationDetails;

internal class GetOperation : Operations.GetOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

\t\tpublic override ResourceID? ResourceId() => new ScopeId();

\t\tpublic override Type? ResponseObject() => typeof(ReservationRecommendationDetailsModelModel);

\t\tpublic override Type? OptionsObject() => typeof(GetOperation.GetOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Consumption/reservationRecommendationDetails";

    internal class GetOptions
    {
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
