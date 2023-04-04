using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationRecoveryServicesProviders;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationRecoveryServicesProviders";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByReplicationFabricsOperation(),
        new PurgeOperation(),
        new RefreshProviderOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AgentVersionStatusConstant),
        typeof(HealthErrorCustomerResolvabilityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddRecoveryServicesProviderInputModel),
        typeof(AddRecoveryServicesProviderInputPropertiesModel),
        typeof(HealthErrorModel),
        typeof(IdentityProviderDetailsModel),
        typeof(IdentityProviderInputModel),
        typeof(InnerHealthErrorModel),
        typeof(RecoveryServicesProviderModel),
        typeof(RecoveryServicesProviderPropertiesModel),
        typeof(VersionDetailsModel),
    };
}
