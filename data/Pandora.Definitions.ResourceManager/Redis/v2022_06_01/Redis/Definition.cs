using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2022_06_01.Redis;

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
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DayOfWeekConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(RebootTypeConstant),
        typeof(RedisKeyTypeConstant),
        typeof(ReplicationRoleConstant),
        typeof(SkuFamilyConstant),
        typeof(SkuNameConstant),
        typeof(TlsVersionConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameAvailabilityParametersModel),
        typeof(ExportRDBParametersModel),
        typeof(ImportRDBParametersModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(RedisAccessKeysModel),
        typeof(RedisCommonPropertiesRedisConfigurationModel),
        typeof(RedisCreateParametersModel),
        typeof(RedisCreatePropertiesModel),
        typeof(RedisFirewallRuleModel),
        typeof(RedisFirewallRulePropertiesModel),
        typeof(RedisForceRebootResponseModel),
        typeof(RedisInstanceDetailsModel),
        typeof(RedisLinkedServerModel),
        typeof(RedisLinkedServerCreateParametersModel),
        typeof(RedisLinkedServerCreatePropertiesModel),
        typeof(RedisLinkedServerPropertiesModel),
        typeof(RedisLinkedServerWithPropertiesModel),
        typeof(RedisPatchScheduleModel),
        typeof(RedisPropertiesModel),
        typeof(RedisRebootParametersModel),
        typeof(RedisRegenerateKeyParametersModel),
        typeof(RedisResourceModel),
        typeof(RedisUpdateParametersModel),
        typeof(RedisUpdatePropertiesModel),
        typeof(ScheduleEntriesModel),
        typeof(ScheduleEntryModel),
        typeof(SkuModel),
        typeof(UpgradeNotificationModel),
    };
}
