// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserOnenoteNotebookSectionPage;

internal class CreateUserByIdOnenoteNotebookByIdSectionByIdPageByIdCopyToSectionOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateUserByIdOnenoteNotebookByIdSectionByIdPageByIdCopyToSectionRequestModel);
    public override ResourceID? ResourceId() => new UserIdOnenoteNotebookIdSectionIdPageId();
    public override Type? ResponseObject() => typeof(OnenoteOperationModel);
    public override string? UriSuffix() => "/copyToSection";
}
