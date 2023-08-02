using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Api;

internal class Definition : ResourceDefinition
{
    public string Name => "Api";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetEntityTagOperation(),
        new ListByServiceOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApiTypeConstant),
        typeof(BearerTokenSendingMethodsConstant),
        typeof(ContentFormatConstant),
        typeof(ProtocolConstant),
        typeof(SoapApiTypeConstant),
        typeof(TranslateRequiredQueryParametersConductConstant),
        typeof(VersioningSchemeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiContactInformationModel),
        typeof(ApiContractModel),
        typeof(ApiContractPropertiesModel),
        typeof(ApiContractUpdatePropertiesModel),
        typeof(ApiCreateOrUpdateParameterModel),
        typeof(ApiCreateOrUpdatePropertiesModel),
        typeof(ApiCreateOrUpdatePropertiesWsdlSelectorModel),
        typeof(ApiLicenseInformationModel),
        typeof(ApiUpdateContractModel),
        typeof(ApiVersionSetContractDetailsModel),
        typeof(AuthenticationSettingsContractModel),
        typeof(OAuth2AuthenticationSettingsContractModel),
        typeof(OpenIdAuthenticationSettingsContractModel),
        typeof(SubscriptionKeyParameterNamesContractModel),
    };
}
