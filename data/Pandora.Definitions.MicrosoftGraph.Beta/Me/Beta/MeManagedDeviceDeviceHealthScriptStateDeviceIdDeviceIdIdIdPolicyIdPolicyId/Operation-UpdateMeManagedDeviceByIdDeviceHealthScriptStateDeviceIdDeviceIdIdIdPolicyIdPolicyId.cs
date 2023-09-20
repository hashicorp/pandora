// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDeviceDeviceHealthScriptStateDeviceIdDeviceIdIdIdPolicyIdPolicyId;

internal class UpdateMeManagedDeviceByIdDeviceHealthScriptStateDeviceIdDeviceIdIdIdPolicyIdPolicyIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(DeviceHealthScriptPolicyStateModel);
    public override ResourceID? ResourceId() => new MeManagedDeviceId();
    public override Type? ResponseObject() => typeof(DeviceHealthScriptPolicyStateModel);
    public override string? UriSuffix() => "/deviceHealthScriptStates/deviceId='{deviceId}',id='{id}',policyId='{policyId}'";
}
