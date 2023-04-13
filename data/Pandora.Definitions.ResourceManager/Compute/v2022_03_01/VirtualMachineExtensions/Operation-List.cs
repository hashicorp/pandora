using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineExtensions;

internal class ListOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new VirtualMachineId();

    public override Type? ResponseObject() => typeof(VirtualMachineExtensionsListResultModel);

    public override Type? OptionsObject() => typeof(ListOperation.ListOptions);

    public override string? UriSuffix() => "/extensions";

    internal class ListOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
