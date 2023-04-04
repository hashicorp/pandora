using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.DeletedWorkspaces;

internal class Definition : ResourceDefinition
{
    public string Name => "DeletedWorkspaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
        new ListByResourceGroupOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataIngestionStatusConstant),
        typeof(DataSourceTypeConstant),
        typeof(PublicNetworkAccessTypeConstant),
        typeof(WorkspaceEntityStatusConstant),
        typeof(WorkspaceSkuNameEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PrivateLinkScopedResourceModel),
        typeof(WorkspaceModel),
        typeof(WorkspaceCappingModel),
        typeof(WorkspaceListResultModel),
        typeof(WorkspacePropertiesModel),
        typeof(WorkspaceSkuModel),
    };
}
