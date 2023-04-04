using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2023_01_31.DigitalTwinsInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "DigitalTwinsInstance";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DigitalTwinsCreateOrUpdateOperation(),
        new DigitalTwinsDeleteOperation(),
        new DigitalTwinsGetOperation(),
        new DigitalTwinsListOperation(),
        new DigitalTwinsListByResourceGroupOperation(),
        new DigitalTwinsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectionPropertiesProvisioningStateConstant),
        typeof(PrivateLinkServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectionPropertiesModel),
        typeof(ConnectionStateModel),
        typeof(DigitalTwinsDescriptionModel),
        typeof(DigitalTwinsPatchDescriptionModel),
        typeof(DigitalTwinsPatchPropertiesModel),
        typeof(DigitalTwinsPropertiesModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
    };
}
