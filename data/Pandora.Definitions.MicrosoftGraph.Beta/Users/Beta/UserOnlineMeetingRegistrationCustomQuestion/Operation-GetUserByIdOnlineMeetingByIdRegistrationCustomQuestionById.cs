// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnlineMeetingRegistrationCustomQuestion;

internal class GetUserByIdOnlineMeetingByIdRegistrationCustomQuestionByIdOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new UserIdOnlineMeetingIdRegistrationCustomQuestionId();
    public override Type? ResponseObject() => typeof(MeetingRegistrationQuestionModel);
    public override string? UriSuffix() => null;
}
