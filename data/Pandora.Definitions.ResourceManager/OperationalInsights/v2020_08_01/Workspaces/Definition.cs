using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.Workspaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Workspaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GatewaysDeleteOperation(),
        new GetOperation(),
        new IntelligencePacksDisableOperation(),
        new IntelligencePacksEnableOperation(),
        new IntelligencePacksListOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ManagementGroupsListOperation(),
        new SchemaGetOperation(),
        new SharedKeysGetSharedKeysOperation(),
        new SharedKeysRegenerateOperation(),
        new UpdateOperation(),
        new UsagesListOperation(),
        new WorkspacePurgeGetPurgeStatusOperation(),
        new WorkspacePurgePurgeOperation(),
    };
}
