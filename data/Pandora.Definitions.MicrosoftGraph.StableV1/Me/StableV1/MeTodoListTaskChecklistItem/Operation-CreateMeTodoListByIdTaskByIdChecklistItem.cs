// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeTodoListTaskChecklistItem;

internal class CreateMeTodoListByIdTaskByIdChecklistItemOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ChecklistItemModel);
    public override ResourceID? ResourceId() => new MeTodoListIdTaskId();
    public override Type? ResponseObject() => typeof(ChecklistItemModel);
    public override string? UriSuffix() => "/checklistItems";
}
