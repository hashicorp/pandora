using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiManagementService;

internal class Definition : ResourceDefinition
{
    public string Name => "ApiManagementService";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ApplyNetworkConfigurationUpdatesOperation(),
        new BackupOperation(),
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetDomainOwnershipIdentifierOperation(),
        new GetSsoTokenOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new RestoreOperation(),
        new UpdateOperation(),
    };
}
