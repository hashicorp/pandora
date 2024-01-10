using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Recommendations;

internal class DisableRecommendationForHostingEnvironmentOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new HostingEnvironmentRecommendationId();

    public override Type? OptionsObject() => typeof(DisableRecommendationForHostingEnvironmentOperation.DisableRecommendationForHostingEnvironmentOptions);

    public override string? UriSuffix() => "/disable";

    internal class DisableRecommendationForHostingEnvironmentOptions
    {
        [QueryStringName("environmentName")]
        public string EnvironmentName { get; set; }
    }
}
