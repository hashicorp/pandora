using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;

internal class AdaptiveApplicationControlsListOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(AdaptiveApplicationControlGroupsModel);

    public override Type? OptionsObject() => typeof(AdaptiveApplicationControlsListOperation.AdaptiveApplicationControlsListOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Security/applicationWhitelistings";

    internal class AdaptiveApplicationControlsListOptions
    {
        [QueryStringName("includePathRecommendations")]
        [Optional]
        public bool IncludePathRecommendations { get; set; }

        [QueryStringName("summary")]
        [Optional]
        public bool Summary { get; set; }
    }
}
