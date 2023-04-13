using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.EdgeModules;

internal class EdgeModulesListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "@nextLink";

    public override ResourceID? ResourceId() => new VideoAnalyzerId();

    public override Type NestedItemType() => typeof(EdgeModuleEntityModel);

    public override Type? OptionsObject() => typeof(EdgeModulesListOperation.EdgeModulesListOptions);

    public override string? UriSuffix() => "/edgeModules";

    internal class EdgeModulesListOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$orderby")]
        [Optional]
        public string Orderby { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
