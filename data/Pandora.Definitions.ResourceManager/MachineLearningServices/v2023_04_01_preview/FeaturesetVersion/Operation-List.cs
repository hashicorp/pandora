using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.FeaturesetVersion;

internal class ListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new FeaturesetId();

    public override Type NestedItemType() => typeof(FeaturesetVersionResourceModel);

    public override Type? OptionsObject() => typeof(ListOperation.ListOptions);

    public override string? UriSuffix() => "/versions";

    internal class ListOptions
    {
        [QueryStringName("createdBy")]
        [Optional]
        public string CreatedBy { get; set; }

        [QueryStringName("description")]
        [Optional]
        public string Description { get; set; }

        [QueryStringName("listViewType")]
        [Optional]
        public ListViewTypeConstant ListViewType { get; set; }

        [QueryStringName("pageSize")]
        [Optional]
        public int PageSize { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }

        [QueryStringName("stage")]
        [Optional]
        public string Stage { get; set; }

        [QueryStringName("tags")]
        [Optional]
        public string Tags { get; set; }

        [QueryStringName("version")]
        [Optional]
        public string Version { get; set; }

        [QueryStringName("versionName")]
        [Optional]
        public string VersionName { get; set; }
    }
}
