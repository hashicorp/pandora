using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ConnectionGateways;

internal class Definition : ResourceDefinition
{
    public string Name => "ConnectionGateways";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConnectionGatewayInstallationsGetOperation(),
        new ConnectionGatewayInstallationsListOperation(),
        new ConnectionGatewaysCreateOrUpdateOperation(),
        new ConnectionGatewaysDeleteOperation(),
        new ConnectionGatewaysGetOperation(),
        new ConnectionGatewaysListOperation(),
        new ConnectionGatewaysListByResourceGroupOperation(),
        new ConnectionGatewaysUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectionGatewayDefinitionModel),
        typeof(ConnectionGatewayDefinitionCollectionModel),
        typeof(ConnectionGatewayDefinitionPropertiesModel),
        typeof(ConnectionGatewayInstallationDefinitionModel),
        typeof(ConnectionGatewayInstallationDefinitionCollectionModel),
        typeof(ConnectionGatewayInstallationDefinitionPropertiesModel),
        typeof(ConnectionGatewayReferenceModel),
    };
}
