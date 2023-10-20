using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.DataContainerRegistry;

internal class Definition : ResourceDefinition
{
    public string Name => "DataContainerRegistry";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RegistryDataContainersCreateOrUpdateOperation(),
        new RegistryDataContainersDeleteOperation(),
        new RegistryDataContainersGetOperation(),
        new RegistryDataContainersListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataTypeConstant),
        typeof(ListViewTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataContainerModel),
        typeof(DataContainerResourceModel),
    };
}
