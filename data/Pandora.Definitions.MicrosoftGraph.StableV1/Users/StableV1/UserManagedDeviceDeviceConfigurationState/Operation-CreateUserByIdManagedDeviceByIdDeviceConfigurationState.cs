// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserManagedDeviceDeviceConfigurationState;

internal class CreateUserByIdManagedDeviceByIdDeviceConfigurationStateOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(DeviceConfigurationStateModel);
    public override ResourceID? ResourceId() => new UserIdManagedDeviceId();
    public override Type? ResponseObject() => typeof(DeviceConfigurationStateModel);
    public override string? UriSuffix() => "/deviceConfigurationStates";
}
