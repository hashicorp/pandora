using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2022_12_01.Registries;

internal class Definition : ResourceDefinition
{
    public string Name => "Registries";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GenerateCredentialsOperation(),
        new GetOperation(),
        new GetPrivateLinkResourceOperation(),
        new ImportImageOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListCredentialsOperation(),
        new ListPrivateLinkResourcesOperation(),
        new ListUsagesOperation(),
        new RegenerateCredentialOperation(),
        new UpdateOperation(),
    };
}
