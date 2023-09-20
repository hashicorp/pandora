// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDeviceWindowsProtectionState;

internal class UpdateMeManagedDeviceByIdWindowsProtectionStateOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(WindowsProtectionStateModel);
    public override ResourceID? ResourceId() => new MeManagedDeviceId();
    public override Type? ResponseObject() => typeof(WindowsProtectionStateModel);
    public override string? UriSuffix() => "/windowsProtectionState";
}
