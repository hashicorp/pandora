using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedInstanceEncryptionProtectors;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedInstanceEncryptionProtectors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new GetOperation(),
        new ListByInstanceOperation(),
        new RevalidateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ServerKeyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedInstanceEncryptionProtectorModel),
        typeof(ManagedInstanceEncryptionProtectorPropertiesModel),
    };
}
