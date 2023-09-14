using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ServerDependencyMapController;

internal class Definition : ResourceDefinition
{
    public string Name => "ServerDependencyMapController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ClientGroupMembersOperation(),
        new ExportDependenciesOperation(),
        new GenerateCoarseMapOperation(),
        new GenerateDetailedMapOperation(),
        new ServerGroupMembersOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DependencyMapServiceMapextensionsClientGroupMembersRequestModel),
        typeof(DependencyMapServiceMapextensionsDependencyMapRequestFiltersModel),
        typeof(DependencyMapServiceMapextensionsExportDependenciesRequestModel),
        typeof(DependencyMapServiceMapextensionsScopeMapRequestModel),
        typeof(DependencyMapServiceMapextensionsServerGroupMembersRequestModel),
        typeof(DependencyMapServiceMapextensionsSingleMachineDetailedMapRequestModel),
    };
}
