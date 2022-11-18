using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

internal class DeploymentsListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new AppId();

\t\tpublic override Type NestedItemType() => typeof(DeploymentResourceModel);

\t\tpublic override Type? OptionsObject() => typeof(DeploymentsListOperation.DeploymentsListOptions);

\t\tpublic override string? UriSuffix() => "/deployments";

    internal class DeploymentsListOptions
    {
        [QueryStringName("version")]
        [Optional]
        public List<string> Version { get; set; }
    }
}
