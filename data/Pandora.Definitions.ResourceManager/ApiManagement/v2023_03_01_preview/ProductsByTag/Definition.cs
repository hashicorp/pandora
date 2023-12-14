using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ProductsByTag;

internal class Definition : ResourceDefinition
{
    public string Name => "ProductsByTag";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ProductListByTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApiTypeConstant),
        typeof(BearerTokenSendingMethodsConstant),
        typeof(ProductStateConstant),
        typeof(ProtocolConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiContactInformationModel),
        typeof(ApiLicenseInformationModel),
        typeof(ApiTagResourceContractPropertiesModel),
        typeof(AuthenticationSettingsContractModel),
        typeof(OAuth2AuthenticationSettingsContractModel),
        typeof(OpenIdAuthenticationSettingsContractModel),
        typeof(OperationTagResourceContractPropertiesModel),
        typeof(ProductTagResourceContractPropertiesModel),
        typeof(SubscriptionKeyParameterNamesContractModel),
        typeof(TagResourceContractModel),
        typeof(TagTagResourceContractPropertiesModel),
    };
}
