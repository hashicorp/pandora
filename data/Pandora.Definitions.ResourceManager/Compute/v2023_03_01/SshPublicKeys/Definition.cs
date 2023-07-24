using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.SshPublicKeys;

internal class Definition : ResourceDefinition
{
    public string Name => "SshPublicKeys";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GenerateKeyPairOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SshPublicKeyGenerateKeyPairResultModel),
        typeof(SshPublicKeyResourceModel),
        typeof(SshPublicKeyResourcePropertiesModel),
        typeof(SshPublicKeyUpdateResourceModel),
    };
}
