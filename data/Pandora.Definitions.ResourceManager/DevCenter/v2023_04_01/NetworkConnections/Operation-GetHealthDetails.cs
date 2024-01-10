using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.NetworkConnections;

internal class GetHealthDetailsOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new NetworkConnectionId();

    public override Type? ResponseObject() => typeof(HealthCheckStatusDetailsModel);

    public override string? UriSuffix() => "/healthChecks/latest";


}
