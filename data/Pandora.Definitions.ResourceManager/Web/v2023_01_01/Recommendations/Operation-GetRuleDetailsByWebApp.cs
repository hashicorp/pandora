using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Recommendations;

internal class GetRuleDetailsByWebAppOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SiteRecommendationId();

    public override Type? ResponseObject() => typeof(RecommendationRuleModel);

    public override Type? OptionsObject() => typeof(GetRuleDetailsByWebAppOperation.GetRuleDetailsByWebAppOptions);

    internal class GetRuleDetailsByWebAppOptions
    {
        [QueryStringName("recommendationId")]
        [Optional]
        public string RecommendationId { get; set; }

        [QueryStringName("updateSeen")]
        [Optional]
        public bool UpdateSeen { get; set; }
    }
}
