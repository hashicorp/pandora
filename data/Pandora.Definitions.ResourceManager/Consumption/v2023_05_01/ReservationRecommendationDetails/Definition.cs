using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.ReservationRecommendationDetails;

internal class Definition : ResourceDefinition
{
    public string Name => "ReservationRecommendationDetails";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LookBackPeriodConstant),
        typeof(ScopeConstant),
        typeof(TermConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ReservationRecommendationDetailsCalculatedSavingsPropertiesModel),
        typeof(ReservationRecommendationDetailsModelModel),
        typeof(ReservationRecommendationDetailsPropertiesModel),
        typeof(ReservationRecommendationDetailsResourcePropertiesModel),
        typeof(ReservationRecommendationDetailsSavingsPropertiesModel),
        typeof(ReservationRecommendationDetailsUsagePropertiesModel),
    };
}
