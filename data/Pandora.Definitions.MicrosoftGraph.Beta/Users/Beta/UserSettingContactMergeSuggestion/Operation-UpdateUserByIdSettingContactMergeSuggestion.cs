// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserSettingContactMergeSuggestion;

internal class UpdateUserByIdSettingContactMergeSuggestionOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ContactMergeSuggestionsModel);
    public override ResourceID? ResourceId() => new UserId();
    public override Type? ResponseObject() => typeof(ContactMergeSuggestionsModel);
    public override string? UriSuffix() => "/settings/contactMergeSuggestions";
}
