using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2019_09_01.QueryPackQueries;

internal class Definition : ResourceDefinition
{
    public string Name => "QueryPackQueries";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new QueriesDeleteOperation(),
        new QueriesGetOperation(),
        new QueriesListOperation(),
        new QueriesPutOperation(),
        new QueriesSearchOperation(),
        new QueriesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LogAnalyticsQueryPackQueryModel),
        typeof(LogAnalyticsQueryPackQueryPropertiesModel),
        typeof(LogAnalyticsQueryPackQueryPropertiesRelatedModel),
        typeof(LogAnalyticsQueryPackQuerySearchPropertiesModel),
        typeof(LogAnalyticsQueryPackQuerySearchPropertiesRelatedModel),
    };
}
