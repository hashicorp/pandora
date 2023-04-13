using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

internal class DeploymentsListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new AppId();

    public override Type NestedItemType() => typeof(DeploymentResourceModel);

    public override Type? OptionsObject() => typeof(DeploymentsListOperation.DeploymentsListOptions);

    public override string? UriSuffix() => "/deployments";

    internal class DeploymentsListOptions
    {
        [QueryStringName("version")]
        [Optional]
        public List<string> Version { get; set; }
    }
}
