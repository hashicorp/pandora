// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileLanguage;

internal class UpdateMeProfileLanguageByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(LanguageProficiencyModel);
    public override ResourceID? ResourceId() => new MeProfileLanguageId();
    public override Type? ResponseObject() => typeof(LanguageProficiencyModel);
    public override string? UriSuffix() => null;
}
