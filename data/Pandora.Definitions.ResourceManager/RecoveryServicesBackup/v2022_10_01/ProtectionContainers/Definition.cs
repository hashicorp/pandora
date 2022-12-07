using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.ProtectionContainers;

internal class Definition : ResourceDefinition
{
    public string Name => "ProtectionContainers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new InquireOperation(),
        new RefreshOperation(),
        new RegisterOperation(),
        new UnregisterOperation(),
    };
}
