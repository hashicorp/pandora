using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineRunCommands;

internal class GetByVirtualMachineOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new VirtualMachineRunCommandId();

\t\tpublic override Type? ResponseObject() => typeof(VirtualMachineRunCommandModel);

\t\tpublic override Type? OptionsObject() => typeof(GetByVirtualMachineOperation.GetByVirtualMachineOptions);

    internal class GetByVirtualMachineOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
