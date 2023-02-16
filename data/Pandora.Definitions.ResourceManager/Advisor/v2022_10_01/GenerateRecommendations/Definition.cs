using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.GenerateRecommendations;

internal class Definition : ResourceDefinition
{
    public string Name => "GenerateRecommendations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RecommendationsGenerateOperation(),
        new RecommendationsGetGenerateStatusOperation(),
    };
}
