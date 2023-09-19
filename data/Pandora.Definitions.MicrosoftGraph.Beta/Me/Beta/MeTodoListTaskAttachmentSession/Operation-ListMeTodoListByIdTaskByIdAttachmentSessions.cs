// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeTodoListTaskAttachmentSession;

internal class ListMeTodoListByIdTaskByIdAttachmentSessionsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new MeTodoListIdTaskId();
    public override Type NestedItemType() => typeof(AttachmentSessionCollectionResponseModel);
    public override string? UriSuffix() => "/attachmentSessions";
}
