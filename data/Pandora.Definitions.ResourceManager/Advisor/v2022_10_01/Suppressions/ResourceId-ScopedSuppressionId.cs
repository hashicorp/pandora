using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.Suppressions;

internal class ScopedSuppressionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}/suppressions/{suppressionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("resourceUri"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAdvisor", "Microsoft.Advisor"),
        ResourceIDSegment.Static("staticRecommendations", "recommendations"),
        ResourceIDSegment.UserSpecified("recommendationId"),
        ResourceIDSegment.Static("staticSuppressions", "suppressions"),
        ResourceIDSegment.UserSpecified("suppressionName"),
    };
}
