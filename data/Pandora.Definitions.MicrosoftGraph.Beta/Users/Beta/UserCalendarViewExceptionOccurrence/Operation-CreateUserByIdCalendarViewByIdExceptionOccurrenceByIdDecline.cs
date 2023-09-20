// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarViewExceptionOccurrence;

internal class CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdDeclineOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(CreateUserByIdCalendarViewByIdExceptionOccurrenceByIdDeclineRequestModel);
    public override ResourceID? ResourceId() => new UserIdCalendarViewIdExceptionOccurrenceId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/decline";
}
