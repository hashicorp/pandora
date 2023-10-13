using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.FavoritesAPIs;

internal class FavoritesListOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ComponentId();

    public override Type? ResponseObject() => typeof(List<ApplicationInsightsComponentFavoriteModel>);

    public override Type? OptionsObject() => typeof(FavoritesListOperation.FavoritesListOptions);

    public override string? UriSuffix() => "/favorites";

    internal class FavoritesListOptions
    {
        [QueryStringName("canFetchContent")]
        [Optional]
        public bool CanFetchContent { get; set; }

        [QueryStringName("favoriteType")]
        [Optional]
        public FavoriteTypeConstant FavoriteType { get; set; }

        [QueryStringName("sourceType")]
        [Optional]
        public FavoriteSourceTypeConstant SourceType { get; set; }

        [QueryStringName("tags")]
        [Optional]
        public Csv<string> Tags { get; set; }
    }
}
