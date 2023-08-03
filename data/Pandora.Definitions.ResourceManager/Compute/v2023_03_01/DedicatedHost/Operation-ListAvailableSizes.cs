using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.DedicatedHost;

internal class ListAvailableSizesOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new HostId();

    public override Type? ResponseObject() => typeof(DedicatedHostSizeListResultModel);

    public override string? UriSuffix() => "/hostSizes";


}
