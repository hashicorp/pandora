using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2023_11_01.ReservationRecommendations;

internal class Definition : ResourceDefinition
{
    public string Name => "ReservationRecommendations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ReservationRecommendationKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AmountModel),
        typeof(LegacyReservationRecommendationModel),
        typeof(LegacyReservationRecommendationPropertiesModel),
        typeof(LegacySharedScopeReservationRecommendationPropertiesModel),
        typeof(LegacySingleScopeReservationRecommendationPropertiesModel),
        typeof(ModernReservationRecommendationModel),
        typeof(ModernReservationRecommendationPropertiesModel),
        typeof(ModernSharedScopeReservationRecommendationPropertiesModel),
        typeof(ModernSingleScopeReservationRecommendationPropertiesModel),
        typeof(ReservationRecommendationModel),
        typeof(SkuPropertyModel),
    };
}
