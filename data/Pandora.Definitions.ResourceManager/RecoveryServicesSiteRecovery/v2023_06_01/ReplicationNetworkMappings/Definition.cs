using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationNetworkMappings;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationNetworkMappings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByReplicationNetworksOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureToAzureCreateNetworkMappingInputModel),
        typeof(AzureToAzureNetworkMappingSettingsModel),
        typeof(AzureToAzureUpdateNetworkMappingInputModel),
        typeof(CreateNetworkMappingInputModel),
        typeof(CreateNetworkMappingInputPropertiesModel),
        typeof(FabricSpecificCreateNetworkMappingInputModel),
        typeof(FabricSpecificUpdateNetworkMappingInputModel),
        typeof(NetworkMappingModel),
        typeof(NetworkMappingFabricSpecificSettingsModel),
        typeof(NetworkMappingPropertiesModel),
        typeof(UpdateNetworkMappingInputModel),
        typeof(UpdateNetworkMappingInputPropertiesModel),
        typeof(VMmToAzureCreateNetworkMappingInputModel),
        typeof(VMmToAzureNetworkMappingSettingsModel),
        typeof(VMmToAzureUpdateNetworkMappingInputModel),
        typeof(VMmToVMmCreateNetworkMappingInputModel),
        typeof(VMmToVMmNetworkMappingSettingsModel),
        typeof(VMmToVMmUpdateNetworkMappingInputModel),
    };
}
