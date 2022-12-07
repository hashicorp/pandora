using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_12_01.UpdateRuns;

internal class Definition : ResourceDefinition
{
    public string Name => "UpdateRuns";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new UpdateRunsDeleteOperation(),
        new UpdateRunsGetOperation(),
        new UpdateRunsListOperation(),
        new UpdateRunsPutOperation(),
    };
}
