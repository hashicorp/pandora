using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.AnalyticsItemsAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "AnalyticsItemsAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AnalyticsItemsDeleteOperation(),
        new AnalyticsItemsGetOperation(),
        new AnalyticsItemsListOperation(),
        new AnalyticsItemsPutOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ItemScopeConstant),
        typeof(ItemTypeConstant),
        typeof(ItemTypeParameterConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationInsightsComponentAnalyticsItemModel),
        typeof(ApplicationInsightsComponentAnalyticsItemPropertiesModel),
    };
}
