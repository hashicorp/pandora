// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalRemoteDesktopSecurityConfigurationTargetDeviceGroup;

internal class UpdateServicePrincipalByIdRemoteDesktopSecurityConfigurationTargetDeviceGroupByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(TargetDeviceGroupModel);
    public override ResourceID? ResourceId() => new ServicePrincipalIdRemoteDesktopSecurityConfigurationTargetDeviceGroupId();
    public override Type? ResponseObject() => typeof(TargetDeviceGroupModel);
    public override string? UriSuffix() => null;
}
