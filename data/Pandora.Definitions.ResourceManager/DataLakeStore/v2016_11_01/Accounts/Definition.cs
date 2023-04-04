using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts;

internal class Definition : ResourceDefinition
{
    public string Name => "Accounts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new EnableKeyVaultOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataLakeStoreAccountStateConstant),
        typeof(DataLakeStoreAccountStatusConstant),
        typeof(EncryptionConfigTypeConstant),
        typeof(EncryptionProvisioningStateConstant),
        typeof(EncryptionStateConstant),
        typeof(FirewallAllowAzureIPsStateConstant),
        typeof(FirewallStateConstant),
        typeof(TierTypeConstant),
        typeof(TrustedIdProviderStateConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameAvailabilityParametersModel),
        typeof(CreateDataLakeStoreAccountParametersModel),
        typeof(CreateDataLakeStoreAccountPropertiesModel),
        typeof(CreateFirewallRuleWithAccountParametersModel),
        typeof(CreateOrUpdateFirewallRulePropertiesModel),
        typeof(CreateOrUpdateTrustedIdProviderPropertiesModel),
        typeof(CreateOrUpdateVirtualNetworkRulePropertiesModel),
        typeof(CreateTrustedIdProviderWithAccountParametersModel),
        typeof(CreateVirtualNetworkRuleWithAccountParametersModel),
        typeof(DataLakeStoreAccountModel),
        typeof(DataLakeStoreAccountBasicModel),
        typeof(DataLakeStoreAccountPropertiesModel),
        typeof(DataLakeStoreAccountPropertiesBasicModel),
        typeof(EncryptionConfigModel),
        typeof(FirewallRuleModel),
        typeof(FirewallRulePropertiesModel),
        typeof(KeyVaultMetaInfoModel),
        typeof(NameAvailabilityInformationModel),
        typeof(TrustedIdProviderModel),
        typeof(TrustedIdProviderPropertiesModel),
        typeof(UpdateDataLakeStoreAccountParametersModel),
        typeof(UpdateDataLakeStoreAccountPropertiesModel),
        typeof(UpdateEncryptionConfigModel),
        typeof(UpdateFirewallRulePropertiesModel),
        typeof(UpdateFirewallRuleWithAccountParametersModel),
        typeof(UpdateKeyVaultMetaInfoModel),
        typeof(UpdateTrustedIdProviderPropertiesModel),
        typeof(UpdateTrustedIdProviderWithAccountParametersModel),
        typeof(UpdateVirtualNetworkRulePropertiesModel),
        typeof(UpdateVirtualNetworkRuleWithAccountParametersModel),
        typeof(VirtualNetworkRuleModel),
        typeof(VirtualNetworkRulePropertiesModel),
    };
}
