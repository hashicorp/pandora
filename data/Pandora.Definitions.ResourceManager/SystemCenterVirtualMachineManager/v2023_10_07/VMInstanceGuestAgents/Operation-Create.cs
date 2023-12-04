using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.VMInstanceGuestAgents;

internal class CreateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(GuestAgentModel);

    public override ResourceID? ResourceId() => new ScopeId();

    public override string? UriSuffix() => "/providers/Microsoft.ScVmm/virtualMachineInstances/default/guestAgents/default";


}
