using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineExtensionImages;

internal class ListVersionsOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new TypeId();

    public override Type? ResponseObject() => typeof(List<VirtualMachineExtensionImageModel>);

    public override Type? OptionsObject() => typeof(ListVersionsOperation.ListVersionsOptions);

    public override string? UriSuffix() => "/versions";

    internal class ListVersionsOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$orderby")]
        [Optional]
        public string Orderby { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
