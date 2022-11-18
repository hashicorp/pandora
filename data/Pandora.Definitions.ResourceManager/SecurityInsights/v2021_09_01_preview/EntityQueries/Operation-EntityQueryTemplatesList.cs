using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.EntityQueries;

internal class EntityQueryTemplatesListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type NestedItemType() => typeof(EntityQueryTemplateModel);

\t\tpublic override Type? OptionsObject() => typeof(EntityQueryTemplatesListOperation.EntityQueryTemplatesListOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.SecurityInsights/entityQueryTemplates";

    internal class EntityQueryTemplatesListOptions
    {
        [QueryStringName("kind")]
        [Optional]
        public KindConstant Kind { get; set; }
    }
}
