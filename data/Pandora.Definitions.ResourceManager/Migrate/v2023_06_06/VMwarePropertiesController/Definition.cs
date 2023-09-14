using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.VMwarePropertiesController;

internal class Definition : ResourceDefinition
{
    public string Name => "VMwarePropertiesController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new UpdateDependencyMapStatusOperation(),
        new UpdatePropertiesOperation(),
        new UpdateRunAsAccountOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DependencyMapMachineInputModel),
        typeof(MachineMetadataModel),
        typeof(MachineMetadataCollectionModel),
        typeof(RunAsAccountMachineInputModel),
        typeof(TagsMachineInputModel),
        typeof(UpdateMachineDepMapStatusModel),
        typeof(UpdateMachineRunAsAccountModel),
        typeof(UpdateMachineTagsModel),
    };
}
