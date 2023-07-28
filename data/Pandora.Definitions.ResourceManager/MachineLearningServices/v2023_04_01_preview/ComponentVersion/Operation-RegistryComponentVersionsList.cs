using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.ComponentVersion;

internal class RegistryComponentVersionsListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new RegistryComponentId();

    public override Type NestedItemType() => typeof(ComponentVersionResourceModel);

    public override Type? OptionsObject() => typeof(RegistryComponentVersionsListOperation.RegistryComponentVersionsListOptions);

    public override string? UriSuffix() => "/versions";

    internal class RegistryComponentVersionsListOptions
    {
        [QueryStringName("$orderBy")]
        [Optional]
        public string OrderBy { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }

        [QueryStringName("stage")]
        [Optional]
        public string Stage { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
