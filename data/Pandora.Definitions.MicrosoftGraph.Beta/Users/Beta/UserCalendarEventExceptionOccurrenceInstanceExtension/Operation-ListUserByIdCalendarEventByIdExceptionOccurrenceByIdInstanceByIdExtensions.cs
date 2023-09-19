// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarEventExceptionOccurrenceInstanceExtension;

internal class ListUserByIdCalendarEventByIdExceptionOccurrenceByIdInstanceByIdExtensionsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdCalendarEventIdExceptionOccurrenceIdInstanceId();
    public override Type NestedItemType() => typeof(ExtensionCollectionResponseModel);
    public override string? UriSuffix() => "/extensions";
}
