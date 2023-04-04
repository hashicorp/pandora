using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.CustomAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "CustomAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CustomApisCreateOrUpdateOperation(),
        new CustomApisDeleteOperation(),
        new CustomApisExtractApiDefinitionFromWsdlOperation(),
        new CustomApisGetOperation(),
        new CustomApisListOperation(),
        new CustomApisListByResourceGroupOperation(),
        new CustomApisListWsdlInterfacesOperation(),
        new CustomApisMoveOperation(),
        new CustomApisUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApiTypeConstant),
        typeof(ConnectionParameterTypeConstant),
        typeof(WsdlImportMethodConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiOAuthSettingsModel),
        typeof(ApiOAuthSettingsParameterModel),
        typeof(ApiResourceBackendServiceModel),
        typeof(ApiResourceDefinitionsModel),
        typeof(ConnectionParameterModel),
        typeof(CustomApiDefinitionModel),
        typeof(CustomApiDefinitionCollectionModel),
        typeof(CustomApiPropertiesDefinitionModel),
        typeof(CustomApiReferenceModel),
        typeof(WsdlDefinitionModel),
        typeof(WsdlServiceModel),
        typeof(WsdlServiceCollectionModel),
    };
}
