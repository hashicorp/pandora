// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeMailFolderChildFolder;

internal class CreateMeMailFolderByIdChildFolderByIdMoveOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateMeMailFolderByIdChildFolderByIdMoveRequestModel);
    public override ResourceID? ResourceId() => new MeMailFolderIdChildFolderId();
    public override Type? ResponseObject() => typeof(MailFolderModel);
    public override string? UriSuffix() => "/move";
}
