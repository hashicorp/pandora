using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Recommendations;

internal class Definition : ResourceDefinition
{
    public string Name => "Recommendations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DisableAllForHostingEnvironmentOperation(),
        new DisableAllForWebAppOperation(),
        new DisableRecommendationForHostingEnvironmentOperation(),
        new DisableRecommendationForSiteOperation(),
        new DisableRecommendationForSubscriptionOperation(),
        new GetRuleDetailsByHostingEnvironmentOperation(),
        new GetRuleDetailsByWebAppOperation(),
        new ListOperation(),
        new ListHistoryForHostingEnvironmentOperation(),
        new ListHistoryForWebAppOperation(),
        new ListRecommendedRulesForHostingEnvironmentOperation(),
        new ListRecommendedRulesForWebAppOperation(),
        new ResetAllFiltersOperation(),
        new ResetAllFiltersForHostingEnvironmentOperation(),
        new ResetAllFiltersForWebAppOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ChannelsConstant),
        typeof(NotificationLevelConstant),
        typeof(ResourceScopeTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RecommendationModel),
        typeof(RecommendationPropertiesModel),
        typeof(RecommendationRuleModel),
        typeof(RecommendationRulePropertiesModel),
    };
}
