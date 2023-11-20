using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.NamespacesNetworkSecurityPerimeterConfigurations;

internal class NetworkSecurityPerimeterConfigurationListOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new NamespaceId();

    public override Type? ResponseObject() => typeof(NetworkSecurityPerimeterConfigurationListModel);

    public override string? UriSuffix() => "/networkSecurityPerimeterConfigurations";


}
