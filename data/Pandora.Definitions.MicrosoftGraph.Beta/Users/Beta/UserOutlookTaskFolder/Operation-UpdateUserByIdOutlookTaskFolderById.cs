// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOutlookTaskFolder;

internal class UpdateUserByIdOutlookTaskFolderByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(OutlookTaskFolderModel);
    public override ResourceID? ResourceId() => new UserIdOutlookTaskFolderId();
    public override Type? ResponseObject() => typeof(OutlookTaskFolderModel);
    public override string? UriSuffix() => null;
}
