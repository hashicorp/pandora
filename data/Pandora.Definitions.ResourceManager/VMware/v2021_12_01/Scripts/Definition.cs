using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.Scripts;

internal class Definition : ResourceDefinition
{
    public string Name => "Scripts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ScriptCmdletsGetOperation(),
        new ScriptCmdletsListOperation(),
        new ScriptExecutionsCreateOrUpdateOperation(),
        new ScriptExecutionsDeleteOperation(),
        new ScriptExecutionsGetOperation(),
        new ScriptExecutionsGetExecutionLogsOperation(),
        new ScriptExecutionsListOperation(),
        new ScriptPackagesGetOperation(),
        new ScriptPackagesListOperation(),
    };
}
