// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteSectionPage;

internal class CreateUserByIdOnenoteSectionByIdPageByIdCopyToSectionOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateUserByIdOnenoteSectionByIdPageByIdCopyToSectionRequestModel);
    public override ResourceID? ResourceId() => new UserIdOnenoteSectionIdPageId();
    public override Type? ResponseObject() => typeof(OnenoteOperationModel);
    public override string? UriSuffix() => "/copyToSection";
}
