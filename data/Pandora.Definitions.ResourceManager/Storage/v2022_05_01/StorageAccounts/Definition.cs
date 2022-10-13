using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.StorageAccounts;

internal class Definition : ResourceDefinition
{
    public string Name => "StorageAccounts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AbortHierarchicalNamespaceMigrationOperation(),
        new CheckNameAvailabilityOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new FailoverOperation(),
        new GetPropertiesOperation(),
        new HierarchicalNamespaceMigrationOperation(),
        new ListOperation(),
        new ListAccountSASOperation(),
        new ListByResourceGroupOperation(),
        new ListKeysOperation(),
        new ListServiceSASOperation(),
        new RegenerateKeyOperation(),
        new RestoreBlobRangesOperation(),
        new RevokeUserDelegationKeysOperation(),
        new UpdateOperation(),
    };
}
