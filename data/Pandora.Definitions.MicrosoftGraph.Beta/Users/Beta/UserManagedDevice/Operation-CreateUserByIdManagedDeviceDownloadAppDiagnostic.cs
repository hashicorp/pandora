// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDevice;

internal class CreateUserByIdManagedDeviceDownloadAppDiagnosticOperation : Operations.PostOperation
{
    public override string? ContentType() => "application/octet-stream";
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateUserByIdManagedDeviceDownloadAppDiagnosticRequestModel);
    public override ResourceID? ResourceId() => new UserId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/managedDevices/downloadAppDiagnostics";
}
