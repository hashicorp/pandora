using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineInstances;

internal class DeleteOperation : Pandora.Definitions.Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.NoContent,
        };

    public override bool LongRunning() => true;

    public override ResourceID? ResourceId() => new ScopeId();

    public override Type? OptionsObject() => typeof(DeleteOperation.DeleteOptions);

    public override string? UriSuffix() => "/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default";

    internal class DeleteOptions
    {
        [QueryStringName("deleteFromHost")]
        [Optional]
        public bool DeleteFromHost { get; set; }

        [QueryStringName("force")]
        [Optional]
        public bool Force { get; set; }
    }
}
