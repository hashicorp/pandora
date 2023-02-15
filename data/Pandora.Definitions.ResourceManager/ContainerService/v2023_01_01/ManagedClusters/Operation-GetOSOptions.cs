using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_01.ManagedClusters;

internal class GetOSOptionsOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new LocationId();

    public override Type? ResponseObject() => typeof(OSOptionProfileModel);

    public override Type? OptionsObject() => typeof(GetOSOptionsOperation.GetOSOptionsOptions);

    public override string? UriSuffix() => "/osOptions/default";

    internal class GetOSOptionsOptions
    {
        [QueryStringName("resource-type")]
        [Optional]
        public string ResourceType { get; set; }
    }
}
