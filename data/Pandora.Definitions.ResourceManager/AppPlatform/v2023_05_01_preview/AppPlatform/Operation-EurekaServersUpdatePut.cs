using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_05_01_preview.AppPlatform;

internal class EurekaServersUpdatePutOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(EurekaServerResourceModel);

    public override ResourceID? ResourceId() => new SpringId();

    public override Type? ResponseObject() => typeof(EurekaServerResourceModel);

    public override string? UriSuffix() => "/eurekaServers/default";


}
