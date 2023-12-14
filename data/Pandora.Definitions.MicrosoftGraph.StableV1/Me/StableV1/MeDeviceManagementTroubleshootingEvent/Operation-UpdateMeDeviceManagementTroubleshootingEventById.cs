// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeDeviceManagementTroubleshootingEvent;

internal class UpdateMeDeviceManagementTroubleshootingEventByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(DeviceManagementTroubleshootingEventModel);
    public override ResourceID? ResourceId() => new MeDeviceManagementTroubleshootingEventId();
    public override Type? ResponseObject() => typeof(DeviceManagementTroubleshootingEventModel);
    public override string? UriSuffix() => null;
}
