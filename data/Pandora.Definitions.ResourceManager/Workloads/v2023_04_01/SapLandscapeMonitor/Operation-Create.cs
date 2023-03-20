using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SapLandscapeMonitor;

internal class CreateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(SapLandscapeMonitorModel);

    public override ResourceID? ResourceId() => new MonitorId();

    public override Type? ResponseObject() => typeof(SapLandscapeMonitorModel);

    public override string? UriSuffix() => "/sapLandscapeMonitor/default";


}
