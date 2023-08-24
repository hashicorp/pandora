using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_07_01.Registries;

internal class Definition : ResourceDefinition
{
    public string Name => "Registries";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GenerateCredentialsOperation(),
        new GetOperation(),
        new GetPrivateLinkResourceOperation(),
        new ImportImageOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListCredentialsOperation(),
        new ListPrivateLinkResourcesOperation(),
        new ListUsagesOperation(),
        new RegenerateCredentialOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionConstant),
        typeof(ActionsRequiredConstant),
        typeof(ConnectionStatusConstant),
        typeof(DefaultActionConstant),
        typeof(EncryptionStatusConstant),
        typeof(ExportPolicyStatusConstant),
        typeof(ImportModeConstant),
        typeof(NetworkRuleBypassOptionsConstant),
        typeof(PasswordNameConstant),
        typeof(PolicyStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(RegistryUsageUnitConstant),
        typeof(SkuNameConstant),
        typeof(SkuTierConstant),
        typeof(TokenPasswordNameConstant),
        typeof(TrustPolicyTypeConstant),
        typeof(ZoneRedundancyConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EncryptionPropertyModel),
        typeof(ExportPolicyModel),
        typeof(GenerateCredentialsParametersModel),
        typeof(GenerateCredentialsResultModel),
        typeof(IPRuleModel),
        typeof(ImportImageParametersModel),
        typeof(ImportSourceModel),
        typeof(ImportSourceCredentialsModel),
        typeof(KeyVaultPropertiesModel),
        typeof(NetworkRuleSetModel),
        typeof(PoliciesModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkResourceModel),
        typeof(PrivateLinkResourcePropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(QuarantinePolicyModel),
        typeof(RegenerateCredentialParametersModel),
        typeof(RegistryModel),
        typeof(RegistryListCredentialsResultModel),
        typeof(RegistryPasswordModel),
        typeof(RegistryPropertiesModel),
        typeof(RegistryPropertiesUpdateParametersModel),
        typeof(RegistryUpdateParametersModel),
        typeof(RegistryUsageModel),
        typeof(RegistryUsageListResultModel),
        typeof(RetentionPolicyModel),
        typeof(SkuModel),
        typeof(StatusModel),
        typeof(TokenPasswordModel),
        typeof(TrustPolicyModel),
    };
}
