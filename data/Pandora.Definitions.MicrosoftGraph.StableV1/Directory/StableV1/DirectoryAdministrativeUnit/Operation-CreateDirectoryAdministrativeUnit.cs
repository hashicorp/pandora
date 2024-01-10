// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Directory.StableV1.DirectoryAdministrativeUnit;

internal class CreateDirectoryAdministrativeUnitOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AdministrativeUnitModel);
    public override ResourceID? ResourceId() => null;
    public override Type? ResponseObject() => typeof(AdministrativeUnitModel);
    public override string? UriSuffix() => "/directory/administrativeUnits";
}
