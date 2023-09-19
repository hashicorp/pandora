// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnenoteNotebook;

internal class GetMeOnenoteNotebooksNotebookFromWebUrlOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(GetMeOnenoteNotebooksNotebookFromWebUrlRequestModel);
    public override ResourceID? ResourceId() => null;
    public override Type? ResponseObject() => typeof(CopyNotebookModelModel);
    public override string? UriSuffix() => "/me/onenote/notebooks/getNotebookFromWebUrl";
}
