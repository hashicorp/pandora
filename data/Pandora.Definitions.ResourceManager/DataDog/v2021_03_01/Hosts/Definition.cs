using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.Hosts;

internal class Definition : ResourceDefinition
{
    public string Name => "Hosts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MonitorsListHostsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DatadogHostModel),
        typeof(DatadogHostMetadataModel),
        typeof(DatadogInstallMethodModel),
        typeof(DatadogLogsAgentModel),
    };
}
