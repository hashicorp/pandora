using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2020_01_01.GetRecommendations;

internal class Definition : ResourceDefinition
{
    public string Name => "GetRecommendations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RecommendationsGetOperation(),
        new RecommendationsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CategoryConstant),
        typeof(ImpactConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RecommendationPropertiesModel),
        typeof(ResourceMetadataModel),
        typeof(ResourceRecommendationBaseModel),
        typeof(ShortDescriptionModel),
    };
}
