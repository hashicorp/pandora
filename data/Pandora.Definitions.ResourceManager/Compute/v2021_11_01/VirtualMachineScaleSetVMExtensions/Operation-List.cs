using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSetVMExtensions;

internal class ListOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new VirtualMachineScaleSetVirtualMachineId();

\t\tpublic override Type? ResponseObject() => typeof(VirtualMachineScaleSetVMExtensionsListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(ListOperation.ListOptions);

\t\tpublic override string? UriSuffix() => "/extensions";

    internal class ListOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
