using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Factories;

internal class Definition : ResourceDefinition
{
    public string Name => "Factories";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConfigureFactoryRepoOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetDataPlaneAccessOperation(),
        new GetGitHubAccessTokenOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FactoryIdentityTypeConstant),
        typeof(GlobalParameterTypeConstant),
        typeof(PublicNetworkAccessConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessPolicyResponseModel),
        typeof(CMKIdentityDefinitionModel),
        typeof(EncryptionConfigurationModel),
        typeof(FactoryModel),
        typeof(FactoryGitHubConfigurationModel),
        typeof(FactoryIdentityModel),
        typeof(FactoryPropertiesModel),
        typeof(FactoryRepoConfigurationModel),
        typeof(FactoryRepoUpdateModel),
        typeof(FactoryUpdateParametersModel),
        typeof(FactoryUpdatePropertiesModel),
        typeof(FactoryVSTSConfigurationModel),
        typeof(GitHubAccessTokenRequestModel),
        typeof(GitHubAccessTokenResponseModel),
        typeof(GitHubClientSecretModel),
        typeof(GlobalParameterSpecificationModel),
        typeof(PurviewConfigurationModel),
        typeof(UserAccessPolicyModel),
    };
}
