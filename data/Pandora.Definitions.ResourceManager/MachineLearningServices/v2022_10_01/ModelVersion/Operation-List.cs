using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.ModelVersion;

internal class ListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ModelId();

    public override Type NestedItemType() => typeof(ModelVersionResourceModel);

    public override Type? OptionsObject() => typeof(ListOperation.ListOptions);

    public override string? UriSuffix() => "/versions";

    internal class ListOptions
    {
        [QueryStringName("description")]
        [Optional]
        public string Description { get; set; }

        [QueryStringName("feed")]
        [Optional]
        public string Feed { get; set; }

        [QueryStringName("listViewType")]
        [Optional]
        public ListViewTypeConstant ListViewType { get; set; }

        [QueryStringName("offset")]
        [Optional]
        public int Offset { get; set; }

        [QueryStringName("$orderBy")]
        [Optional]
        public string OrderBy { get; set; }

        [QueryStringName("properties")]
        [Optional]
        public string Properties { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }

        [QueryStringName("tags")]
        [Optional]
        public string Tags { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }

        [QueryStringName("version")]
        [Optional]
        public string Version { get; set; }
    }
}
