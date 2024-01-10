// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalRemoteDesktopSecurityConfigurationTargetDeviceGroup;

internal class CreateServicePrincipalByIdRemoteDesktopSecurityConfigurationTargetDeviceGroupOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(TargetDeviceGroupModel);
    public override ResourceID? ResourceId() => new ServicePrincipalId();
    public override Type? ResponseObject() => typeof(TargetDeviceGroupModel);
    public override string? UriSuffix() => "/remoteDesktopSecurityConfiguration/targetDeviceGroups";
}
