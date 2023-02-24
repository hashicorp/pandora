using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.VMHost;

internal class Definition : ResourceDefinition
{
    public string Name => "VMHost";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MonitorListVMHostUpdateOperation(),
        new MonitorListVMHostsOperation(),
        new MonitorVMHostPayloadOperation(),
        new SubAccountListVMHostUpdateOperation(),
        new SubAccountListVMHostsOperation(),
        new SubAccountVMHostPayloadOperation(),
    };
}
