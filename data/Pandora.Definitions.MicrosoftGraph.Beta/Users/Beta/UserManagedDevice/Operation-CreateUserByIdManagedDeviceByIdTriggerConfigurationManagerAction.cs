// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDevice;

internal class CreateUserByIdManagedDeviceByIdTriggerConfigurationManagerActionOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(CreateUserByIdManagedDeviceByIdTriggerConfigurationManagerActionRequestModel);
    public override ResourceID? ResourceId() => new UserIdManagedDeviceId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/triggerConfigurationManagerAction";
}
