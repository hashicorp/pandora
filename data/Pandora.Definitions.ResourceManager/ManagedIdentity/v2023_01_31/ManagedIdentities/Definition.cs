using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2023_01_31.ManagedIdentities;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedIdentities";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new FederatedIdentityCredentialsCreateOrUpdateOperation(),
        new FederatedIdentityCredentialsDeleteOperation(),
        new FederatedIdentityCredentialsGetOperation(),
        new FederatedIdentityCredentialsListOperation(),
        new SystemAssignedIdentitiesGetByScopeOperation(),
        new UserAssignedIdentitiesCreateOrUpdateOperation(),
        new UserAssignedIdentitiesDeleteOperation(),
        new UserAssignedIdentitiesGetOperation(),
        new UserAssignedIdentitiesListByResourceGroupOperation(),
        new UserAssignedIdentitiesListBySubscriptionOperation(),
        new UserAssignedIdentitiesUpdateOperation(),
    };
}
