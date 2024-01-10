// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarGroupCalendarCalendarViewExceptionOccurrenceInstance;

internal class CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel);
    public override ResourceID? ResourceId() => new UserIdCalendarGroupIdCalendarIdCalendarViewIdExceptionOccurrenceIdInstanceId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/snoozeReminder";
}
