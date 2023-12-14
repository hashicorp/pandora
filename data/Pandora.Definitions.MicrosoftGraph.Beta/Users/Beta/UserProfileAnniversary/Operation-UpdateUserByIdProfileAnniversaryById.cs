// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileAnniversary;

internal class UpdateUserByIdProfileAnniversaryByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(PersonAnnualEventModel);
    public override ResourceID? ResourceId() => new UserIdProfileAnniversaryId();
    public override Type? ResponseObject() => typeof(PersonAnnualEventModel);
    public override string? UriSuffix() => null;
}
