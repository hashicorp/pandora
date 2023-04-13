using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.WorkloadNetworks;

internal class CreateDnsServiceOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(WorkloadNetworkDnsServiceModel);

    public override ResourceID? ResourceId() => new DnsServiceId();

    public override Type? ResponseObject() => typeof(WorkloadNetworkDnsServiceModel);


}
