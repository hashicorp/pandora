using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.ManagedHsms;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedHsms";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckMhsmNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetDeletedOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListDeletedOperation(),
        new PurgeDeletedOperation(),
        new UpdateOperation(),
    };
}
