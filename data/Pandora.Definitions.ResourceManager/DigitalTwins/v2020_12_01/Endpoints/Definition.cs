using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2020_12_01.Endpoints;

internal class Definition : ResourceDefinition
{
    public string Name => "Endpoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DigitalTwinsEndpointCreateOrUpdateOperation(),
        new DigitalTwinsEndpointDeleteOperation(),
        new DigitalTwinsEndpointGetOperation(),
        new DigitalTwinsEndpointListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthenticationTypeConstant),
        typeof(EndpointProvisioningStateConstant),
        typeof(EndpointTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DigitalTwinsEndpointResourceModel),
        typeof(DigitalTwinsEndpointResourcePropertiesModel),
        typeof(EventGridModel),
        typeof(EventHubModel),
        typeof(ServiceBusModel),
    };
}
