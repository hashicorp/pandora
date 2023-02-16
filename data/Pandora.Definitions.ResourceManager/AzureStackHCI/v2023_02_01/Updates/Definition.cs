using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_02_01.Updates;

internal class Definition : ResourceDefinition
{
    public string Name => "Updates";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new UpdatesDeleteOperation(),
        new UpdatesGetOperation(),
        new UpdatesListOperation(),
        new UpdatesPostOperation(),
        new UpdatesPutOperation(),
    };
}
