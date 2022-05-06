using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedIdentity";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SystemAssignedIdentitiesGetByScopeOperation(),
        new UserAssignedIdentitiesCreateOrUpdateOperation(),
        new UserAssignedIdentitiesDeleteOperation(),
        new UserAssignedIdentitiesGetOperation(),
        new UserAssignedIdentitiesListByResourceGroupOperation(),
        new UserAssignedIdentitiesListBySubscriptionOperation(),
        new UserAssignedIdentitiesUpdateOperation(),
    };
}
