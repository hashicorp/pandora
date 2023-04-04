using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPRecommendations;

internal class Definition : ResourceDefinition
{
    public string Name => "SAPRecommendations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SAPSizingRecommendationsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SAPDatabaseScaleMethodConstant),
        typeof(SAPDatabaseTypeConstant),
        typeof(SAPDeploymentTypeConstant),
        typeof(SAPEnvironmentTypeConstant),
        typeof(SAPHighAvailabilityTypeConstant),
        typeof(SAPProductTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SAPSizingRecommendationRequestModel),
        typeof(SAPSizingRecommendationResultModel),
        typeof(SingleServerRecommendationResultModel),
        typeof(ThreeTierRecommendationResultModel),
    };
}
