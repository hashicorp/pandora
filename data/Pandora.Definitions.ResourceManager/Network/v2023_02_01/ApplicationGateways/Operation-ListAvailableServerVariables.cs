using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.ApplicationGateways;

internal class ListAvailableServerVariablesOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(List<string>);

    public override string? UriSuffix() => "/providers/Microsoft.Network/applicationGatewayAvailableServerVariables";


}
