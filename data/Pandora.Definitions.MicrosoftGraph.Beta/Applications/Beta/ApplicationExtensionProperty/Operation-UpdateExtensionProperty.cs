using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationExtensionProperty;

internal class UpdateExtensionPropertyOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ExtensionPropertyModel);
    public override ResourceID? ResourceId() => new ExtensionPropertyId();
    public override Type? ResponseObject() => typeof(ExtensionPropertyModel);
    public override string? UriSuffix() => null;
}
