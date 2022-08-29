using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2021_06_01.Redis;

internal class Definition : ResourceDefinition
{
    public string Name => "Redis";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new ExportDataOperation(),
        new FirewallRulesCreateOrUpdateOperation(),
        new FirewallRulesDeleteOperation(),
        new FirewallRulesGetOperation(),
        new FirewallRulesListOperation(),
        new ForceRebootOperation(),
        new GetOperation(),
        new ImportDataOperation(),
        new LinkedServerCreateOperation(),
        new LinkedServerDeleteOperation(),
        new LinkedServerGetOperation(),
        new LinkedServerListOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new ListUpgradeNotificationsOperation(),
        new PatchSchedulesCreateOrUpdateOperation(),
        new PatchSchedulesDeleteOperation(),
        new PatchSchedulesGetOperation(),
        new PatchSchedulesListByRedisResourceOperation(),
        new RegenerateKeyOperation(),
        new UpdateOperation(),
    };
}
