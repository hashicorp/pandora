using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSets;

internal class GetInstanceViewOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new VirtualMachineScaleSetId();

\t\tpublic override Type? ResponseObject() => typeof(VirtualMachineScaleSetInstanceViewModel);

\t\tpublic override string? UriSuffix() => "/instanceView";


}
