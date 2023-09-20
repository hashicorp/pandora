// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Directory.StableV1.DirectoryCustomSecurityAttributeDefinitionAllowedValue;

internal class CreateDirectoryCustomSecurityAttributeDefinitionByIdAllowedValueOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AllowedValueModel);
    public override ResourceID? ResourceId() => new DirectoryCustomSecurityAttributeDefinitionId();
    public override Type? ResponseObject() => typeof(AllowedValueModel);
    public override string? UriSuffix() => "/allowedValues";
}
