using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecurityRecommendations;

internal class IotRecommendationsListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new IotSecuritySolutionId();

    public override Type NestedItemType() => typeof(IotRecommendationModel);

    public override Type? OptionsObject() => typeof(IotRecommendationsListOperation.IotRecommendationsListOptions);

    public override string? UriSuffix() => "/iotRecommendations";

    internal class IotRecommendationsListOptions
    {
        [QueryStringName("deviceId")]
        [Optional]
        public string DeviceId { get; set; }

        [QueryStringName("$limit")]
        [Optional]
        public int Limit { get; set; }

        [QueryStringName("recommendationType")]
        [Optional]
        public string RecommendationType { get; set; }
    }
}
