// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnlineMeetingRegistrationRegistrant;

internal class UpdateMeOnlineMeetingByIdRegistrationRegistrantByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(MeetingRegistrantBaseModel);
    public override ResourceID? ResourceId() => new MeOnlineMeetingIdRegistrationRegistrantId();
    public override Type? ResponseObject() => typeof(MeetingRegistrantBaseModel);
    public override string? UriSuffix() => null;
}
