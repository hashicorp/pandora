using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ApplicationGatewayWafDynamicManifests;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationGatewayWafDynamicManifests";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ApplicationGatewayWafDynamicManifestsDefaultGetOperation(),
        new ApplicationGatewayWafDynamicManifestsGetOperation(),
    };
}
