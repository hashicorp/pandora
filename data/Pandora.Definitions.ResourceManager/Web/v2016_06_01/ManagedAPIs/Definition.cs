using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ManagedAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ManagedApisGetOperation(),
        new ManagedApisListOperation(),
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
        typeof(ApiResourceGeneralInformationModel),
        typeof(ApiResourceMetadataModel),
        typeof(ApiResourcePoliciesModel),
        typeof(ApiResourcePropertiesModel),
        typeof(ConnectionParameterModel),
        typeof(ManagedApiDefinitionModel),
        typeof(ManagedApiDefinitionCollectionModel),
        typeof(WsdlServiceModel),
    };
}
