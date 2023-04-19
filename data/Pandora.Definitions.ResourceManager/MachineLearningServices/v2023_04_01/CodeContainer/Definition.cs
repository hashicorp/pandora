using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.CodeContainer;

internal class Definition : ResourceDefinition
{
    public string Name => "CodeContainer";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new RegistryCodeContainersCreateOrUpdateOperation(),
        new RegistryCodeContainersDeleteOperation(),
        new RegistryCodeContainersGetOperation(),
        new RegistryCodeContainersListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssetProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CodeContainerModel),
        typeof(CodeContainerResourceModel),
    };
}
