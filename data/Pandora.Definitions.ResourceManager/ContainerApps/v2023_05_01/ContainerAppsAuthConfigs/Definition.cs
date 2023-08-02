using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ContainerAppsAuthConfigs;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerAppsAuthConfigs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByContainerAppOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ClientCredentialMethodConstant),
        typeof(CookieExpirationConventionConstant),
        typeof(ForwardProxyConventionConstant),
        typeof(UnauthenticatedClientActionV2Constant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AllowedAudiencesValidationModel),
        typeof(AllowedPrincipalsModel),
        typeof(AppRegistrationModel),
        typeof(AppleModel),
        typeof(AppleRegistrationModel),
        typeof(AuthConfigModel),
        typeof(AuthConfigPropertiesModel),
        typeof(AuthPlatformModel),
        typeof(AzureActiveDirectoryModel),
        typeof(AzureActiveDirectoryLoginModel),
        typeof(AzureActiveDirectoryRegistrationModel),
        typeof(AzureActiveDirectoryValidationModel),
        typeof(AzureStaticWebAppsModel),
        typeof(AzureStaticWebAppsRegistrationModel),
        typeof(ClientRegistrationModel),
        typeof(CookieExpirationModel),
        typeof(CustomOpenIdConnectProviderModel),
        typeof(DefaultAuthorizationPolicyModel),
        typeof(FacebookModel),
        typeof(ForwardProxyModel),
        typeof(GitHubModel),
        typeof(GlobalValidationModel),
        typeof(GoogleModel),
        typeof(HTTPSettingsModel),
        typeof(HTTPSettingsRoutesModel),
        typeof(IdentityProvidersModel),
        typeof(JwtClaimChecksModel),
        typeof(LoginModel),
        typeof(LoginRoutesModel),
        typeof(LoginScopesModel),
        typeof(NonceModel),
        typeof(OpenIdConnectClientCredentialModel),
        typeof(OpenIdConnectConfigModel),
        typeof(OpenIdConnectLoginModel),
        typeof(OpenIdConnectRegistrationModel),
        typeof(TwitterModel),
        typeof(TwitterRegistrationModel),
    };
}
