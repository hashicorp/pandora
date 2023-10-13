using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.FavoritesAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "FavoritesAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new FavoritesAddOperation(),
        new FavoritesDeleteOperation(),
        new FavoritesGetOperation(),
        new FavoritesListOperation(),
        new FavoritesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FavoriteSourceTypeConstant),
        typeof(FavoriteTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationInsightsComponentFavoriteModel),
    };
}
