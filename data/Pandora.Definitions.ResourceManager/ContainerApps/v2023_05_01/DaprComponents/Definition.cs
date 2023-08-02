using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.DaprComponents;

internal class Definition : ResourceDefinition
{
    public string Name => "DaprComponents";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConnectedEnvironmentsDaprComponentsCreateOrUpdateOperation(),
        new ConnectedEnvironmentsDaprComponentsDeleteOperation(),
        new ConnectedEnvironmentsDaprComponentsGetOperation(),
        new ConnectedEnvironmentsDaprComponentsListOperation(),
        new ConnectedEnvironmentsDaprComponentsListSecretsOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListSecretsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DaprComponentModel),
        typeof(DaprComponentPropertiesModel),
        typeof(DaprMetadataModel),
        typeof(DaprSecretModel),
        typeof(DaprSecretsCollectionModel),
        typeof(SecretModel),
    };
}
