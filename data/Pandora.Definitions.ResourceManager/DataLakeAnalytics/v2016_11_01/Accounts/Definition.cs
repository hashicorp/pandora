using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts;

internal class Definition : ResourceDefinition
{
    public string Name => "Accounts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AADObjectTypeConstant),
        typeof(DataLakeAnalyticsAccountStateConstant),
        typeof(DataLakeAnalyticsAccountStatusConstant),
        typeof(DebugDataAccessLevelConstant),
        typeof(FirewallAllowAzureIPsStateConstant),
        typeof(FirewallStateConstant),
        typeof(NestedResourceProvisioningStateConstant),
        typeof(TierTypeConstant),
        typeof(TypeConstant),
        typeof(VirtualNetworkRuleStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddDataLakeStorePropertiesModel),
        typeof(AddDataLakeStoreWithAccountParametersModel),
        typeof(AddStorageAccountPropertiesModel),
        typeof(AddStorageAccountWithAccountParametersModel),
        typeof(CheckNameAvailabilityParametersModel),
        typeof(ComputePolicyModel),
        typeof(ComputePolicyPropertiesModel),
        typeof(CreateComputePolicyWithAccountParametersModel),
        typeof(CreateDataLakeAnalyticsAccountParametersModel),
        typeof(CreateDataLakeAnalyticsAccountPropertiesModel),
        typeof(CreateFirewallRuleWithAccountParametersModel),
        typeof(CreateOrUpdateComputePolicyPropertiesModel),
        typeof(CreateOrUpdateFirewallRulePropertiesModel),
        typeof(DataLakeAnalyticsAccountModel),
        typeof(DataLakeAnalyticsAccountBasicModel),
        typeof(DataLakeAnalyticsAccountPropertiesModel),
        typeof(DataLakeAnalyticsAccountPropertiesBasicModel),
        typeof(DataLakeStoreAccountInformationModel),
        typeof(DataLakeStoreAccountInformationPropertiesModel),
        typeof(FirewallRuleModel),
        typeof(FirewallRulePropertiesModel),
        typeof(HiveMetastoreModel),
        typeof(HiveMetastorePropertiesModel),
        typeof(NameAvailabilityInformationModel),
        typeof(StorageAccountInformationModel),
        typeof(StorageAccountInformationPropertiesModel),
        typeof(UpdateComputePolicyPropertiesModel),
        typeof(UpdateComputePolicyWithAccountParametersModel),
        typeof(UpdateDataLakeAnalyticsAccountParametersModel),
        typeof(UpdateDataLakeAnalyticsAccountPropertiesModel),
        typeof(UpdateDataLakeStorePropertiesModel),
        typeof(UpdateDataLakeStoreWithAccountParametersModel),
        typeof(UpdateFirewallRulePropertiesModel),
        typeof(UpdateFirewallRuleWithAccountParametersModel),
        typeof(UpdateStorageAccountPropertiesModel),
        typeof(UpdateStorageAccountWithAccountParametersModel),
        typeof(VirtualNetworkRuleModel),
        typeof(VirtualNetworkRulePropertiesModel),
    };
}
