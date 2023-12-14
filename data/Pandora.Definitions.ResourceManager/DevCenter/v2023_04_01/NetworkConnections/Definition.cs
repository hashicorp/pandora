using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.NetworkConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetHealthDetailsOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListHealthDetailsOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DomainJoinTypeConstant),
        typeof(HealthCheckStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(HealthCheckModel),
        typeof(HealthCheckStatusDetailsModel),
        typeof(HealthCheckStatusDetailsPropertiesModel),
        typeof(NetworkConnectionModel),
        typeof(NetworkConnectionUpdateModel),
        typeof(NetworkConnectionUpdatePropertiesModel),
        typeof(NetworkPropertiesModel),
    };
}
