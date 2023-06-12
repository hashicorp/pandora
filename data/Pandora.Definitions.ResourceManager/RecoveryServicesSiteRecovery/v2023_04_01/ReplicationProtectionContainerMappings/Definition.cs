using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationProtectionContainerMappings;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationProtectionContainerMappings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByReplicationProtectionContainersOperation(),
        new PurgeOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AgentAutoUpdateStatusConstant),
        typeof(AutomationAccountAuthenticationTypeConstant),
        typeof(HealthErrorCustomerResolvabilityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(A2AContainerMappingInputModel),
        typeof(A2AProtectionContainerMappingDetailsModel),
        typeof(A2AUpdateContainerMappingInputModel),
        typeof(CreateProtectionContainerMappingInputModel),
        typeof(CreateProtectionContainerMappingInputPropertiesModel),
        typeof(HealthErrorModel),
        typeof(InMageRcmProtectionContainerMappingDetailsModel),
        typeof(InMageRcmUpdateContainerMappingInputModel),
        typeof(InnerHealthErrorModel),
        typeof(ProtectionContainerMappingModel),
        typeof(ProtectionContainerMappingPropertiesModel),
        typeof(ProtectionContainerMappingProviderSpecificDetailsModel),
        typeof(RemoveProtectionContainerMappingInputModel),
        typeof(RemoveProtectionContainerMappingInputPropertiesModel),
        typeof(ReplicationProviderContainerUnmappingInputModel),
        typeof(ReplicationProviderSpecificContainerMappingInputModel),
        typeof(ReplicationProviderSpecificUpdateContainerMappingInputModel),
        typeof(UpdateProtectionContainerMappingInputModel),
        typeof(UpdateProtectionContainerMappingInputPropertiesModel),
        typeof(VMwareCbtContainerMappingInputModel),
        typeof(VMwareCbtProtectionContainerMappingDetailsModel),
    };
}
