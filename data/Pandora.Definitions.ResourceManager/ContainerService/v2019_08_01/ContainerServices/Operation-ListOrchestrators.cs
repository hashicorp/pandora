using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2019_08_01.ContainerServices;

internal class ListOrchestratorsOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new LocationId();

    public override Type? ResponseObject() => typeof(OrchestratorVersionProfileListResultModel);

    public override Type? OptionsObject() => typeof(ListOrchestratorsOperation.ListOrchestratorsOptions);

    public override string? UriSuffix() => "/orchestrators";

    internal class ListOrchestratorsOptions
    {
        [QueryStringName("resource-type")]
        [Optional]
        public string ResourceType { get; set; }
    }
}
