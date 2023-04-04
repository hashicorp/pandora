using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.Links;

internal class Definition : ResourceDefinition
{
    public string Name => "Links";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new LinkerDeleteOperation(),
        new LinkerListConfigurationsOperation(),
        new LinkerUpdateOperation(),
        new LinkerValidateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthTypeConstant),
        typeof(AzureResourceTypeConstant),
        typeof(ClientTypeConstant),
        typeof(SecretTypeConstant),
        typeof(TargetServiceTypeConstant),
        typeof(VNetSolutionTypeConstant),
        typeof(ValidationResultStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthInfoBaseModel),
        typeof(AzureKeyVaultPropertiesModel),
        typeof(AzureResourceModel),
        typeof(AzureResourcePropertiesBaseModel),
        typeof(ConfluentBootstrapServerModel),
        typeof(ConfluentSchemaRegistryModel),
        typeof(KeyVaultSecretReferenceSecretInfoModel),
        typeof(KeyVaultSecretUriSecretInfoModel),
        typeof(LinkerPatchModel),
        typeof(LinkerPropertiesModel),
        typeof(LinkerResourceModel),
        typeof(SecretAuthInfoModel),
        typeof(SecretInfoBaseModel),
        typeof(SecretStoreModel),
        typeof(ServicePrincipalCertificateAuthInfoModel),
        typeof(ServicePrincipalSecretAuthInfoModel),
        typeof(SourceConfigurationModel),
        typeof(SourceConfigurationResultModel),
        typeof(SystemAssignedIdentityAuthInfoModel),
        typeof(TargetServiceBaseModel),
        typeof(UserAssignedIdentityAuthInfoModel),
        typeof(VNetSolutionModel),
        typeof(ValidateOperationResultModel),
        typeof(ValidateResultModel),
        typeof(ValidationResultItemModel),
        typeof(ValueSecretInfoModel),
    };
}
