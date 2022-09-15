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

internal class ForceRecoveryServiceFabricPlatformUpdateDomainWalkOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new VirtualMachineScaleSetId();

    public override Type? ResponseObject() => typeof(RecoveryWalkResponseModel);

    public override Type? OptionsObject() => typeof(ForceRecoveryServiceFabricPlatformUpdateDomainWalkOperation.ForceRecoveryServiceFabricPlatformUpdateDomainWalkOptions);

    public override string? UriSuffix() => "/forceRecoveryServiceFabricPlatformUpdateDomainWalk";

    internal class ForceRecoveryServiceFabricPlatformUpdateDomainWalkOptions
    {
        [QueryStringName("platformUpdateDomain")]
        public int PlatformUpdateDomain { get; set; }
    }
}
