// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupCalendarCalendarViewAttachment;

internal class ListGroupByIdCalendarCalendarViewByIdAttachmentsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdCalendarCalendarViewId();
    public override Type NestedItemType() => typeof(AttachmentCollectionResponseModel);
    public override string? UriSuffix() => "/attachments";
}
