using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.DataTransfer;

internal class Definition : ResourceDefinition
{
    public string Name => "DataTransfer";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServiceCreateOperation(),
        new ServiceDeleteOperation(),
        new ServiceGetOperation(),
    };
}
