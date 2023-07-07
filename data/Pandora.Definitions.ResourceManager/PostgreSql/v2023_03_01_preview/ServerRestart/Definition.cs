using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.ServerRestart;

internal class Definition : ResourceDefinition
{
    public string Name => "ServerRestart";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServersRestartOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FailoverModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RestartParameterModel),
    };
}
