using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.V2WorkspaceConnectionResource;

internal class Definition : ResourceDefinition
{
    public string Name => "V2WorkspaceConnectionResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new WorkspaceConnectionsCreateOperation(),
        new WorkspaceConnectionsDeleteOperation(),
        new WorkspaceConnectionsGetOperation(),
        new WorkspaceConnectionsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectionAuthTypeConstant),
        typeof(ConnectionCategoryConstant),
        typeof(ValueFormatConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessKeyAuthTypeWorkspaceConnectionPropertiesModel),
        typeof(ManagedIdentityAuthTypeWorkspaceConnectionPropertiesModel),
        typeof(NoneAuthTypeWorkspaceConnectionPropertiesModel),
        typeof(PATAuthTypeWorkspaceConnectionPropertiesModel),
        typeof(SASAuthTypeWorkspaceConnectionPropertiesModel),
        typeof(ServicePrincipalAuthTypeWorkspaceConnectionPropertiesModel),
        typeof(UsernamePasswordAuthTypeWorkspaceConnectionPropertiesModel),
        typeof(WorkspaceConnectionAccessKeyModel),
        typeof(WorkspaceConnectionManagedIdentityModel),
        typeof(WorkspaceConnectionPersonalAccessTokenModel),
        typeof(WorkspaceConnectionPropertiesV2Model),
        typeof(WorkspaceConnectionPropertiesV2BasicResourceModel),
        typeof(WorkspaceConnectionServicePrincipalModel),
        typeof(WorkspaceConnectionSharedAccessSignatureModel),
        typeof(WorkspaceConnectionUsernamePasswordModel),
    };
}
